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
    public class OrderLinesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly string _serviceAddress;
        private readonly GrpcChannel _channel;

        public OrderLinesController(IMapper mapper)
        {
            _mapper = mapper;
            _serviceAddress = "https://localhost:5002/";
            _channel = GrpcChannel.ForAddress(_serviceAddress);
        }

        // GET: api/<OrderLine>
        [HttpGet]
        public async Task<List<OrderLine>> GetOrderLines()
        {
            var client = new RemoteOrderLine.RemoteOrderLineClient(_channel);

            OrderLinesReply lists = await client.GetAllAsync(new OrderLineEmptyRequest() { });

            List<OrderLine> list = lists.OrderLines.Select(x => new OrderLine
            {
                OrderLineID = x.OrderLineID,
                OrderID = x.OrderID,
                ProductID = x.ProductID,
                Quantity = x.Quantity
            }).ToList();

            return list;
        }

        // GET: api/<OrderLine>/5
        [HttpGet("{orderID}")]
        public async Task<List<OrderLine>> GetOrderLinesByOrderID(int orderID)
        {
            var client = new RemoteOrderLine.RemoteOrderLineClient(_channel);

            OrderLinesReply lists = await client.GetOrderLinesByOrderIdAsync(new OrderLineByOrderRequest() { OrderID = orderID });

            List<OrderLine> list = lists.OrderLines.Select(x => new OrderLine
            {
                OrderLineID = x.OrderLineID,
                OrderID = x.OrderID,
                ProductID = x.ProductID,
                Quantity = x.Quantity
            }).ToList();

            return list;
        }


        // GET api/<OrderLine>/5
        [HttpGet("{OrderLineId}")]
        public async Task<OrderLine> Get(int OrderLineId)
        {
            var client = new RemoteOrderLine.RemoteOrderLineClient(_channel);

            OrderLineReply reply = await client.GetOrderLineByIdAsync(new OrderLineSearchRequest { OrderLineID = OrderLineId });

            OrderLine OrderLineResponse = _mapper.Map<OrderLine>(reply);

            return OrderLineResponse;
        }

        // POST api/<OrderLine>
        [HttpPost]
        public async Task<bool> Post(OrderLine OrderLine)
        {
            var client = new RemoteOrderLine.RemoteOrderLineClient(_channel);

            OrderLineRequest request = _mapper.Map<OrderLineRequest>(OrderLine);

            OrderLineSuccess reply = await client.AddItemAsync(request);

            return reply.Success;
        }

        // PUT api/<OrderLine>/5
        [HttpPut("{OrderLineId}")]
        public async Task<bool> Put(int OrderLineId, OrderLine OrderLine)
        {
            var client = new RemoteOrderLine.RemoteOrderLineClient(_channel);

            OrderLine.OrderLineID = OrderLineId;

            OrderLineRequest request = _mapper.Map<OrderLineRequest>(OrderLine);

            OrderLineSuccess reply = await client.UpdateByIdAsync(request);

            return reply.Success;
        }

        // DELETE api/<OrderLine>/5
        [HttpDelete("{OrderLineId}")]
        public async Task<bool> Delete(int OrderLineId)
        {
            var client = new RemoteOrderLine.RemoteOrderLineClient(_channel);

            OrderLineSuccess reply = await client.DeleteOrderLineByIdAsync(new OrderLineSearchRequest { OrderLineID = OrderLineId });

            return reply.Success;
        }
    }
}
