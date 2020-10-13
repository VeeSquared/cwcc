using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CampingWorld.Domain.Models;
using CampingWorld.Web.Application.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace CampingWorld.Web.Application.Controllers
{
    public class ReportController : Controller
    {
        public async Task<IActionResult> ReportAsync(string sortOrder)
        {
            DateTime today = DateTime.Today;

            DateTime startDate = today.AddDays(-(int)today.DayOfWeek);
            DateTime endDate = startDate.AddDays(7).AddSeconds(-1);

            ViewBag.QuantitySoldSortParm = String.IsNullOrEmpty(sortOrder) ? "QuantitySold" : "";
            ViewBag.RevenueSortParm = String.IsNullOrEmpty(sortOrder) ? "Revenue" : "";
            ViewBag.ProfitSortParm = String.IsNullOrEmpty(sortOrder) ? "Profit" : "";

            List<Order> orders = new List<Order>();
            List<OrderLine> orderLines = new List<OrderLine>();
            List<Product> products = new List<Product>();

            List<ProductModel> productVM = new List<ProductModel>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:52223/api/Product"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }

                using (var response = await httpClient.GetAsync("http://localhost:52223/api/Order"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    orders = JsonConvert.DeserializeObject<List<Order>>(apiResponse);
                }

                using (var response = await httpClient.GetAsync("http://localhost:52223/api/OrderLines"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    orderLines = JsonConvert.DeserializeObject<List<OrderLine>>(apiResponse);
                }
            }

            var pe = (from p in products
                     from o in orders
                     from ol in orderLines
                     where ol.ProductID == p.ProductID
                     where o.OrderID == ol.OrderID
                     where o.OrderDate >= startDate
                     where o.OrderDate <= endDate.Date
                     select new { p.Cost, p.Name, p.ProductID, p.Price, ol.Quantity }).ToList();
             



            var pen = pe.GroupBy(l => l.ProductID).Select(g => new
                        {
                        ProductName = g.First().Name,
                        Quantity = g.Sum(s => s.Quantity),
                        Price = g.First().Price,
                        Cost = g.First().Cost,
                        ProductID = g.First().ProductID
                        }).ToList();


            if (pen != null)
            {
                foreach (var item in pen)
                {
                    var profit = ((item.Price - item.Cost) * item.Quantity);
                    var revenue = item.Price * item.Quantity;
                    productVM.Add(new ProductModel { Cost = item.Cost, ProductName = item.ProductName, Price = item.Price, ProductId = item.ProductID, Profit = profit, QuantitySold = item.Quantity, Revenue = revenue });
                }

                switch (sortOrder)
                {
                    case "Profit":
                        productVM = productVM.OrderByDescending(o => o.Profit).ToList();
                        break;
                    case "Revenue":
                        productVM = productVM.OrderByDescending(o => o.Revenue).ToList();
                        break;
                    default:
                        productVM = productVM.OrderByDescending(o => o.QuantitySold).ToList();
                        break;
                }
            }


            return View(productVM);
        }
    }
}