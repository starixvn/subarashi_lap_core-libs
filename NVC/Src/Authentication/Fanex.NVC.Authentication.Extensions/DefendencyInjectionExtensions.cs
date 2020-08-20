using Fanex.NVC.Authentication.Extensions.Handlers;
using Fanex.NVC.Authentication.Extensions.Models;
using Fanex.NVC.Authentication.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;

namespace Fanex.NVC.Authentication.Extensions
{
    public static class DefendencyInjectionExtensions
    {
        public static AuthenticationBuilder AddNVCSharedAuth(this AuthenticationBuilder builder, Action<NVCAuthenticationOptions> configureOptions)
        {
            builder.Services.RegisterDI();

            builder
                .AddScheme<NVCAuthenticationOptions, NVCAuthenticationHandler>(NVCAuthSchema.NVCSharedAuth, options =>
                {
                    configureOptions?.Invoke(options);
                    builder.Services.BuildServiceProvider().SetDefaultStrategyOptions(options);
                })
                .Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<NVCAuthenticationOptions>, PostConfigureNVCAuthenticationOptions>());

            return builder;
        }

        public static AuthenticationBuilder AddNVCSharedAuth(this AuthenticationBuilder builder)
        {
            return builder.AddNVCSharedAuth(options =>
                {
                    builder.Services.BuildServiceProvider().SetDefaultStrategyOptions(options);
                });
        }

        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<INVCAuthInfoService>(serviceProvider => new NVCAuthInfoService(serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.Items));
            services.AddTransient<INVCPermissionService, NVCPermissionService>();

            return services;
        }

        private static void SetDefaultStrategyOptions(this ServiceProvider serviceProvider, NVCAuthenticationOptions options)
        {
            if (options.AuthStrategy is null)
            {
                options.AuthStrategy = serviceProvider.GetRequiredService<INVCAuthStrategy>();
            }

            if (options.PrincipalGenerater is null)
            {
                options.PrincipalGenerater = serviceProvider.GetRequiredService<INVCPrincipalGenerater>();
            }
        }

        private static IServiceCollection RegisterDI(this IServiceCollection services)
        {
            services.AddSingleton(_ => NVCSharedAuthManager.NVCAuthStrategy);
            services.AddSingleton(_ => NVCSharedAuthManager.NVCPrincipalGenerater);

            return services;
        }
    }
}