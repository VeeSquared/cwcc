using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using CampingWorld.Domain.Models;
using Proto;
using CampingWorld.Persistence.Data.Customers;

namespace Customer.Web.Service
{
    public class CustomerService : RemoteCustomer.RemoteCustomerBase
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly IUnitOfWorkCustomer _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerService(ILogger<CustomerService> logger, IUnitOfWorkCustomer unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        public override async Task<CustomersReply> GetAll(CustomerEmptyRequest request, ServerCallContext context)
        {
            var Customers = await _unitOfWork.Customers.GetAsync();
            return _mapper.Map<CustomersReply>(Customers);
        }

        public override async Task<CustomerReply> GetCustomerById(CustomerSearchRequest request, ServerCallContext context)
        {
            var Customer = await _unitOfWork.Customers.GetByIdAsync(request.CustomerID);
            return _mapper.Map<CustomerReply>(Customer);
        }

        public override async Task<CustomerSuccess> DeleteCustomerById(CustomerSearchRequest request, ServerCallContext context)
        {
            CustomerSuccess reply = new CustomerSuccess { Success = await _unitOfWork.Customers.DeleteByIdAsync(request.CustomerID) };
            return reply;
        }

        public override async Task<CustomerSuccess> AddItem(CustomerRequest request, ServerCallContext context)
        {
            CustomerSuccess reply = new CustomerSuccess { Success = await _unitOfWork.Customers.AddItemAsync(_mapper.Map<CampingWorld.Domain.Models.Customer>(request)) };
            return reply;
        }

        public override async Task<CustomerSuccess> UpdateById(CustomerRequest request, ServerCallContext context)
        {
            CustomerSuccess reply = new CustomerSuccess { Success = await _unitOfWork.Customers.UpdateByIdAsync(_mapper.Map<CampingWorld.Domain.Models.Customer>(request)) };
            return reply;
        }

    }
}
