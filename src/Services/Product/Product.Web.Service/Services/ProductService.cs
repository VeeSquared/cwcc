
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using CampingWorld.Domain.Models;
using CampingWorld.Persistence.Data.Products;
using Proto;

namespace Product.Web.Service
{
    public class ProductService : RemoteProduct.RemoteProductBase
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IUnitOfWorkProduct _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(ILogger<ProductService> logger, IUnitOfWorkProduct unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        public override async Task<ProductsReply> GetAll(ProductEmptyRequest request, ServerCallContext context)
        {
            var products = await _unitOfWork.Products.GetAsync();
            return _mapper.Map<ProductsReply>(products);
        }

        public override async Task<ProductReply> GetProductById(ProductSearchRequest request, ServerCallContext context)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.ProductID);
            return _mapper.Map<ProductReply>(product);
        }

        public override async Task<ProductSuccess> DeleteProductById(ProductSearchRequest request, ServerCallContext context)
        {
            ProductSuccess reply = new ProductSuccess { Success = await _unitOfWork.Products.DeleteByIdAsync(request.ProductID) };
            return reply;
        }

        public override async Task<ProductSuccess> AddItem(ProductRequest request, ServerCallContext context)
        {
            ProductSuccess reply = new ProductSuccess { Success = await _unitOfWork.Products.AddItemAsync(_mapper.Map<CampingWorld.Domain.Models.Product>(request)) }; 
            return reply;
        }

        public override async Task<ProductSuccess> UpdateById(ProductRequest request, ServerCallContext context)
        {
            ProductSuccess reply = new ProductSuccess { Success = await _unitOfWork.Products.UpdateByIdAsync(_mapper.Map<CampingWorld.Domain.Models.Product>(request)) };
            return reply;
        }

    }
}
