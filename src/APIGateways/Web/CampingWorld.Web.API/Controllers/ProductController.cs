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

namespace CampingWorld.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly string _serviceAddress;
        private readonly GrpcChannel _channel;
        //private readonly string _gchannel;


        /*public ProductController(IMapper mapper, string serviceAddress)
        {
            _mapper = mapper;
            _serviceAddress = serviceAddress;
            _channel = GrpcChannel.ForAddress(_serviceAddress);
        }*/

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
            _serviceAddress = "https://localhost:5001/";
            _channel = GrpcChannel.ForAddress(_serviceAddress);
        }

        // GET: api/<Product>
        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            var client = new RemoteProduct.RemoteProductClient(_channel);

            ProductsReply lists = await client.GetAllAsync(new ProductEmptyRequest() { });

            List<Product> list = lists.Products.Select(x => new Product
            {
                ProductID = x.ProductID,
                Name = x.Name,
                Cost = System.Convert.ToDecimal(x.Cost),
                Price = System.Convert.ToDecimal(x.Price)
            }).ToList();
          
            return list;
        }

        // GET api/<Product>/5
        [HttpGet("{productId}")]
        public async Task<Product> Get(int productId)
        {
            var client = new RemoteProduct.RemoteProductClient(_channel);

            ProductReply reply = await client.GetProductByIdAsync(new ProductSearchRequest { ProductID = productId });

            Product productResponse = _mapper.Map<Product>(reply);

            return productResponse;
        }

        // POST api/<Product>
        [HttpPost]
        public async Task<bool> Post(Product product)
        {
            var client = new RemoteProduct.RemoteProductClient(_channel);

            ProductRequest request = _mapper.Map<ProductRequest>(product);

            ProductSuccess reply = await client.AddItemAsync(request);

            return reply.Success;
        }

        // PUT api/<Product>/5
        [HttpPut("{productId}")]
        public async Task<bool> Put(int productId, Product product)
        {
            var client = new RemoteProduct.RemoteProductClient(_channel);

            product.ProductID = productId;

            ProductRequest request = _mapper.Map<ProductRequest>(product);

            ProductSuccess reply = await client.UpdateByIdAsync(request);

            return reply.Success;
        }

        // DELETE api/<Product>/5
        [HttpDelete("{productId}")]
        public async Task<bool> Delete(int productId)
        {
            var client = new RemoteProduct.RemoteProductClient(_channel);

            ProductSuccess reply = await client.DeleteProductByIdAsync(new ProductSearchRequest { ProductID = productId });

            return reply.Success;
        }

    }
}
