using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Grpc.Net.Client;
using Proto;
using CampingWorld.Domain.Models;
using CampingWorld.Domain.Mappers;
using AutoMapper;
using System.Threading.Channels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CampingWorld.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly string _serviceAddress;
        private readonly GrpcChannel _channel;

        public CustomerController(IMapper mapper)
        {
            _mapper = mapper;
            _serviceAddress = "https://localhost:5003/";
            _channel = GrpcChannel.ForAddress(_serviceAddress);
        }

        // GET: api/<Customer>
        [HttpGet]
        public async Task<List<Customer>> GetCustomers()
        {
            var client = new RemoteCustomer.RemoteCustomerClient(_channel);

            CustomersReply lists = await client.GetAllAsync(new CustomerEmptyRequest() { });

            List<Customer> list = lists.Customers.Select(x => new Customer
            {
                CustomerID = x.CustomerID,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();

            return list;
        }

        // GET api/<customer>/5
        [HttpGet("{customerId}")]
        public async Task<Customer> Get(int customerId)
        {
            var client = new RemoteCustomer.RemoteCustomerClient(_channel);

            CustomerReply reply = await client.GetCustomerByIdAsync(new CustomerSearchRequest { CustomerID = customerId });

            Customer customerResponse = _mapper.Map<Customer>(reply);

            return customerResponse;
        }

        // POST api/<Customer>
        [HttpPost]
        public async Task<bool> Post(Customer customer)
        {
            var client = new RemoteCustomer.RemoteCustomerClient(_channel);

            CustomerRequest request = _mapper.Map<CustomerRequest>(customer);

            CustomerSuccess reply = await client.AddItemAsync(request);

            return reply.Success;
        }

        // PUT api/<Customer>/5
        [HttpPut("{customerId}")]
        public async Task<bool> Put(int customerId, Customer customer)
        {
            var client = new RemoteCustomer.RemoteCustomerClient(_channel);

            customer.CustomerID = customerId;

            CustomerRequest request = _mapper.Map<CustomerRequest>(customer);

            CustomerSuccess reply = await client.UpdateByIdAsync(request);

            return reply.Success;
        }

        // DELETE api/<Customer>/5
        [HttpDelete("{customerId}")]
        public async Task<bool> Delete(int customerId)
        {
            var client = new RemoteCustomer.RemoteCustomerClient(_channel);

            CustomerSuccess reply = await client.DeleteCustomerByIdAsync(new CustomerSearchRequest { CustomerID = customerId });

            return reply.Success;
        }
    }
}
