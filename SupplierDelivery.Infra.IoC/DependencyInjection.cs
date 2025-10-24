using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupplierDelivery.Application.Interfaces;
using SupplierDelivery.Application.Mapping;
using SupplierDelivery.Application.Services;
using SupplierDelivery.Domain.Interfaces;
using SupplierDelivery.Infra.Data.Context;
using SupplierDelivery.Infra.Data.Repositories;

namespace SupplierDelivery.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            //services.AddControllers()
            //    .AddJsonOptions(options =>
            //    {
            //        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            //    });


            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEntregaRepository, EntregaRepository>();


            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IEntregaService, EntregaService>();


            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            //services.AddMediatR(cfg =>
            //{
            //    cfg.RegisterServicesFromAssemblies(
            //        typeof(ProdutoCreateCommandHandler).Assembly
            //    );
            //});

            //var myhandlers = AppDomain.CurrentDomain.Load("OptiControl.Application");
            //services.AddMediatR(cfg =>
            //{
            //    cfg.RegisterServicesFromAssembly(myhandlers);
            //});

            return services;
        }
    }
}
