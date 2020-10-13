using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using CampingWorld.Domain.Models;
using Proto;
using CampingWorld.Persistence.Data.Orders;

namespace OrderLine.Web.Service
{
    public class OrderLineService : RemoteOrderLine.RemoteOrderLineBase
    {
        private readonly ILogger<OrderLineService> _logger;
        private readonly IUnitOfWorkOrderLine _unitOfWork;
        private readonly IMapper _mapper;

        public OrderLineService(ILogger<OrderLineService> logger, IUnitOfWorkOrderLine unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        public override async Task<OrderLinesReply> GetAll(OrderLineEmptyRequest request, ServerCallContext context)
        {
            var OrderLines = await _unitOfWork.OrderLines.GetAsync();
            return _mapper.Map<OrderLinesReply>(OrderLines);
        }

        public override async Task<OrderLineReply> GetOrderLineById(OrderLineSearchRequest request, ServerCallContext context)
        {
            var OrderLine = await _unitOfWork.OrderLines.GetByIdAsync(request.OrderLineID);
            return _mapper.Map<OrderLineReply>(OrderLine);
        }

        public override async Task<OrderLineSuccess> DeleteOrderLineById(OrderLineSearchRequest request, ServerCallContext context)
        {
            OrderLineSuccess reply = new OrderLineSuccess { Success = await _unitOfWork.OrderLines.DeleteByIdAsync(request.OrderLineID) };
            return reply;
        }

        public override async Task<OrderLineSuccess> AddItem(OrderLineRequest request, ServerCallContext context)
        {
            OrderLineSuccess reply = new OrderLineSuccess { Success = await _unitOfWork.OrderLines.AddItemAsync(_mapper.Map<CampingWorld.Domain.Models.OrderLine>(request)) };
            return reply;
        }

        public override async Task<OrderLineSuccess> UpdateById(OrderLineRequest request, ServerCallContext context)
        {
            OrderLineSuccess reply = new OrderLineSuccess { Success = await _unitOfWork.OrderLines.UpdateByIdAsync(_mapper.Map<CampingWorld.Domain.Models.OrderLine>(request)) };
            return reply;
        }

        public override async Task<OrderLinesReply> GetOrderLinesByOrderId(OrderLineByOrderRequest request, ServerCallContext context)
        {
            var OrderLines = await _unitOfWork.OrderLines.GetOrderLinesByOrderIdAsync(request.OrderID);
            return _mapper.Map<OrderLinesReply>(OrderLines);
        }
    }
}
