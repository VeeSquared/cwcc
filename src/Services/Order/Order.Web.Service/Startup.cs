using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CampingWorld.Persistence.Repositories.Orders;
using CampingWorld.Persistence.Repositories;
using Infrastructure.Persistence.Repositories;
using CampingWorld.Persistence.Data.Products;
using AutoMapper;
using System.Reflection;
using CampingWorld.Domain.Mappers;
using CampingWorld.Persistence.Data.Orders;
using OrderLine.Web.Service;

namespace Order.Web.Service
{
    public class Startup
    {
        private IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderLineRepository, OrderLineRepository>();
            services.AddScoped<IUnitOfWorkOrder, UnitOfWorkOrder>();
            services.AddScoped<IUnitOfWorkOrderLine, UnitOfWorkOrderLine>();
            services.AddAutoMapper(typeof(OrderMappingProfile));

            services.AddDbContext<OrderContext>(options => options.UseSqlite(_configuration.GetConnectionString("SQLiteOrderDB"), b => b.MigrationsAssembly("Order.Web.Service")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<OrderService>();
                endpoints.MapGrpcService<OrderLineService>();


                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
