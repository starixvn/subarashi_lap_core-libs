using Fanex.N88.Authentication.Common;
using Fanex.N88.Authentication.Common.Models;
using Fanex.N88.Authentication.Common.Services;
using Fanex.N88.Authentication.Extensions.Handlers;
using Fanex.N88.Authentication.Extensions.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;

namespace Fanex.N88.Authentication.Extensions
{
    public static class DefendencyInjectionExtensions
    {
        public static AuthenticationBuilder AddMPASharedAuth(this AuthenticationBuilder builder, Action<MPAAuthenticationOptions> configureOptions)
        {
            builder.Services.RegisterDI();

            builder
                .AddScheme<MPAAuthenticationOptions, MPAAuthenticationHandler>(AuthenticationSchema.MPASharedAuth, options =>
                {
                    configureOptions?.Invoke(options);
                    builder.Services.BuildServiceProvider().SetDefaultStrategyOptions(options);
                })
                .Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<MPAAuthenticationOptions>, PostConfigureMPAAuthenticationOptions>());

            return builder;
        }

        public static AuthenticationBuilder AddMPASharedAuth(this AuthenticationBuilder builder)
        {
            return builder.AddMPASharedAuth(options =>
                {
                    builder.Services.BuildServiceProvider().SetDefaultStrategyOptions(options);
                });
        }

        private static void SetDefaultStrategyOptions(this ServiceProvider serviceProvider, MPAAuthenticationOptions options)
        {
            if (options.AuthStrategy is null)
            {
                options.AuthStrategy = serviceProvider.GetRequiredService<IMPAAuthStrategy>();
            }

            if (options.PrincipalGenerater is null)
            {
                options.PrincipalGenerater = serviceProvider.GetRequiredService<IMPAPrincipalGenerater>();
            }
        }

        private static IServiceCollection RegisterDI(this IServiceCollection services)
        {
            services.AddSingleton(_ => MPASharedAuthManager.MPAAuthStrategy);
            services.AddSingleton(_ => MPASharedAuthManager.MPAPrincipalGenerater);

            return services;
        }
    }
}