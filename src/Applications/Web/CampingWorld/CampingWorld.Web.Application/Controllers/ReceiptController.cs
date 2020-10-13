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
    public class ReceiptController : Controller
    {


        public async Task<IActionResult> Receipt(string orderStr)
        {
            List<ReceiptModel> receiptVM = new List<ReceiptModel>();

            List<Order> orders = new List<Order>();
            List<OrderLine> orderLines = new List<OrderLine>();
            List<Product> products = new List<Product>();
            List<Customer> customers = new List<Customer>();

            int orderNumber = 0;

            if (orderStr != "" && orderStr != null)
            {
                try
                {
                    orderNumber = Int32.Parse(orderStr);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Unable to parse orderStr");
                }
            }



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

                using (var response = await httpClient.GetAsync("http://localhost:52223/api/Customer"))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    customers = JsonConvert.DeserializeObject<List<Customer>>(apiResponse);
                }
            }

            var pe = (from p in products
                      from o in orders
                      from ol in orderLines
                      from c in customers
                      where ol.ProductID == p.ProductID
                      where o.OrderID == orderNumber
                      where o.OrderID == ol.OrderID
                      where o.CustomerID == c.CustomerID
                      select new { CustomerName = c.FirstName + " " + c.LastName, o.OrderID, o.OrderDate, p.ProductID, p.Name, p.Price, p.Cost, ol.Quantity, ExtendedPrice = ol.Quantity * p.Price }).ToList();

            if (pe != null)
            {
                decimal total = 0;

                foreach (var i in pe)
                {
                    total = total + i.ExtendedPrice;
                }
                foreach (var i in pe)
                {
                    receiptVM.Add(new ReceiptModel { CustomerName = i.CustomerName, Cost = i.Cost, ExtendedPrice = i.ExtendedPrice, OrderDate = i.OrderDate, OrderID = i.OrderID, Price = i.Price, ProductID = i.ProductID, ProductName = i.Name, Quantity = i.Quantity, Total = total }); ;
                }
            }

            return View(receiptVM);
        }
    }
}