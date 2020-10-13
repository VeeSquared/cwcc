using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using CampingWorld.Domain.Models;
using CampingWorld.Persistence.Data.Orders;
using Proto;

namespace Order.Web.Service
{
    public class OrderService : RemoteOrder.RemoteOrderBase
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IUnitOfWorkOrder _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(ILogger<OrderService> logger, IUnitOfWorkOrder unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        public override async Task<OrdersReply> GetAll(OrderEmptyRequest request, ServerCallContext context)
        {
            var Orders = await _unitOfWork.Orders.GetAsync();
            return _mapper.Map<OrdersReply>(Orders);
        }

        public override async Task<OrderReply> GetOrderById(OrderSearchRequest request, ServerCallContext context)
        {
            var Order = await _unitOfWork.Orders.GetByIdAsync(request.OrderID);
            return _mapper.Map<OrderReply>(Order);
        }

        public override async Task<OrderSuccess> DeleteOrderById(OrderSearchRequest request, ServerCallContext context)
        {
            OrderSuccess reply = new OrderSuccess { Success = await _unitOfWork.Orders.DeleteByIdAsync(request.OrderID) };
            return reply;
        }

        public override async Task<OrderSuccess> AddItem(OrderRequest request, ServerCallContext context)
        {
            OrderSuccess reply = new OrderSuccess { Success = await _unitOfWork.Orders.AddItemAsync(_mapper.Map<CampingWorld.Domain.Models.Order>(request)) };
            return reply;
        }

        public override async Task<OrderSuccess> UpdateById(OrderRequest request, ServerCallContext context)
        {
            OrderSuccess reply = new OrderSuccess { Success = await _unitOfWork.Orders.UpdateByIdAsync(_mapper.Map<CampingWorld.Domain.Models.Order>(request)) };
            return reply;
        }

    }
}
