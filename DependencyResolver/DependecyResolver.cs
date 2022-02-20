
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ComicStore.Infrastructure.Data;
using ComicStore.Domain.Contracts.Repositories;
using ComicStore.Domain.Contracts.Services;
using ComicStore.Domain.Entity;
using ComicStore.Domain.Contracts.UnitOfWork;
using ComicStore.Services;
using ComicStore.Domain.Contracts.Repositories.Base;
using ComicStore.Infrastructure.Repositories.Base;
using ComicStore.Infrastructure.UniOfWork;
using ComicStore.Application.Interface;
using ComicStore.Application.Application;
using ComicStore.Infrastructure.Repositories;

namespace ComicStore.Api.DependencyResolver
{
    public static class DependecyResolver
    {
        public static void Resolve(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ComicStoreDbContext>(options => options.UseOracle(Configuration.GetConnectionString("Production")));
            services.AddScoped<IShoppinngCartRepository, CartRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IShoppinngCartService, ShoppingCartService>();
            services.AddScoped<IGenericRepository<CartItems>, GenericRepository<CartItems>>();
            services.AddScoped<ICartItemApplication, CartItemApplication>();
        }
    }
}
