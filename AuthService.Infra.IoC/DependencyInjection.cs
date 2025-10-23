using AuthService.Infra.Data.Context;
using AuthService.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //services.ConfigureApplicationCookie(option =>
            //    option.AccessDeniedPath = "/Account/Login");

            //services.AddControllers()
            //    .AddJsonOptions(options =>
            //    {
            //        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            //    });

            //services.AddScoped<UserManager<ApplicationUser>>();
            //services.AddScoped<RoleManager<IdentityRole>>();
            //services.AddScoped<IAuthenticate, AuthenticateService>();
            //services.AddScoped<AuthenticateService>();
            //services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            //services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

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
