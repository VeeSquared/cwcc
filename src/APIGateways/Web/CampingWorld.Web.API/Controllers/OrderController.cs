using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Grpc.Net.Client;
using Proto;
using CampingWorld.Domain.Models;
using System.Linq;
using CampingWorld.Domain.Mappers;
using AutoMapper;
using System.Threading.Channels;
using System;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CampingWorld.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly string _serviceAddress;
        private readonly GrpcChannel _channel;

        public OrderController(IMapper mapper)
        {
            _mapper = mapper;
            _serviceAddress = "https://localhost:5002/";
            _channel = GrpcChannel.ForAddress(_serviceAddress);
        }

        // GET: api/<Order>
        [HttpGet]
        public async Task<List<Order>> GetOrders()
        {
            var client = new RemoteOrder.RemoteOrderClient(_channel);

            OrdersReply lists = await client.GetAllAsync(new OrderEmptyRequest() { });

            List<Order> list = lists.Orders.Select(x => new Order
            {
                OrderID = x.OrderID,
                CustomerID = x.CustomerID,
                OrderDate = Convert.ToDateTime(x.OrderDate)
            }).ToList();

            return list;
        }

        // GET api/<Order>/5
        [HttpGet("{OrderId}")]
        public async Task<Order> Get(int OrderId)
        {
            var client = new RemoteOrder.RemoteOrderClient(_channel);

            OrderReply reply = await client.GetOrderByIdAsync(new OrderSearchRequest { OrderID = OrderId });

            Order OrderResponse = _mapper.Map<Order>(reply);

            return OrderResponse;
        }

        // POST api/<Order>
        [HttpPost]
        public async Task<bool> Post(Order Order)
        {
            var client = new RemoteOrder.RemoteOrderClient(_channel);

            OrderRequest request = _mapper.Map<OrderRequest>(Order);

            OrderSuccess reply = await client.AddItemAsync(request);

            return reply.Success;
        }

        // PUT api/<Order>/5
        [HttpPut("{OrderId}")]
        public async Task<bool> Put(int OrderId, Order Order)
        {
            var client = new RemoteOrder.RemoteOrderClient(_channel);

            Order.OrderID = OrderId;

            OrderRequest request = _mapper.Map<OrderRequest>(Order);

            OrderSuccess reply = await client.UpdateByIdAsync(request);

            return reply.Success;
        }

        // DELETE api/<Order>/5
        [HttpDelete("{OrderId}")]
        public async Task<bool> Delete(int OrderId)
        {
            var client = new RemoteOrder.RemoteOrderClient(_channel);

            OrderSuccess reply = await client.DeleteOrderByIdAsync(new OrderSearchRequest { OrderID = OrderId });

            return reply.Success;
        }
    }
}
