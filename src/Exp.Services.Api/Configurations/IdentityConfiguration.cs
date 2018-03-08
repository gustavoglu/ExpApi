using Exp.Infra.Identity.Context;
using Exp.Infra.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Exp.Services.Api.Configurations
{
    public class IdentityConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddIdentity<Usuario, IdentityRole>(cfg =>
            {
                cfg.Password.RequireDigit = false;
                cfg.Password.RequireLowercase = false;
                cfg.Password.RequireUppercase = false;
                cfg.Password.RequireNonAlphanumeric = false;
                cfg.Password.RequiredLength = 6;
            })
              .AddEntityFrameworkStores<ContextIdentity>()
              .AddDefaultTokenProviders();
        }
    }
}
