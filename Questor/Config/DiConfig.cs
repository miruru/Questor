using BancoClass.Entities;
using BancoClass.Interfaces;
using BancoClass.Services;
using BaseDomain.Interfaces;
using BaseDomain.Notifications;
using BoletoClass.Entities;
using BoletoClass.Interfaces;
using BoletoClass.Services;
using Data.Context;
using Data.Repository;
using Microsoft.Extensions.Options;
using NetDevPack.Security.JwtSigningCredentials.Interfaces;
using QuestorApi.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Questor.Config
{
    public static class DiConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataDbContext>();

            services.AddScoped<AuthenticationService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Banco
            services.AddScoped<IBancoService, BancoService<Banco>>();
            services.AddScoped<IBancoRepository, BancoRepository>();

            #endregion

            #region Boleto
            services.AddScoped<IBoletoService, BoletoService<Boleto>>();
            services.AddScoped<IBoletoRepository, BoletoRepository>();

            #endregion

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
