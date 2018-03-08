using Exp.Domain.Interfaces.Repository;
using Exp.Domain.Interfaces.UoW;
using Exp.Domain.Interfaces.UserIdentity;
using Exp.Infra.Data.Context;
using Exp.Infra.Data.Inicializers;
using Exp.Infra.Data.Repository;
using Exp.Infra.Data.UoW;
using Exp.Infra.Identity.Context;
using Exp.Infra.Identity.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Exp.Infra.IoC
{
    public class NativeInjection
    {
        public static void AddNativeInjection(IServiceCollection services)
        {
            //Identity
            services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<ContextIdentity>();

            //Infra Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ContextSQLS>();

            //Infrada Data Inicializers
            services.AddTransient<ContaTipoInicializer>();

            // Repositorys
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IContaContatoRepository, ContaContatoRepository>();
            services.AddScoped<IContaEnderecoRepository, ContaEnderecoRepository>();
            services.AddScoped<IContaTipoRepository, ContaTipoRepository>();

            //Services


        }
    }
}
