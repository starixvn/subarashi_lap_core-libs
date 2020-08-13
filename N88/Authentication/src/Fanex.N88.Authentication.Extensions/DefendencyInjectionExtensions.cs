using Fanex.N88.Authentication.Common.Core;
using Fanex.N88.Authentication.Common.Models;
using Fanex.N88.Authentication.Common.Services;
using Fanex.N88.Authentication.Extensions.Handlers;
using Fanex.N88.Authentication.Extensions.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;

namespace Fanex.N88.Authentication.Extensions
{
    public static class DefendencyInjectionExtensions
    {
        public static AuthenticationBuilder AddMPASharedAuth(this AuthenticationBuilder builder, IConfiguration configuration, Action<MPAAuthenticationOptions> configureOptions)
        {
            builder.Services.RegisterDI(configuration);

            builder
                .AddScheme<MPAAuthenticationOptions, MPAAuthenticationHandler>(AuthenticationSchema.MPASharedAuth, configureOptions)
                .Services.TryAddEnumerable(ServiceDescriptor.Singleton<IPostConfigureOptions<MPAAuthenticationOptions>, PostConfigureMPAAuthenticationOptions>());

            return builder;
        }

        public static AuthenticationBuilder AddMPASharedAuth(this AuthenticationBuilder builder, IConfiguration configuration)
        {
            return builder.AddMPASharedAuth(configuration, options =>
                {
                    options.AuthStrategy = builder.Services.BuildServiceProvider().GetRequiredService<IMPAAuthStrategy>();
                });
        }

        private static IServiceCollection RegisterDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISerializer, BinarySerializer>();

            services.AddSingleton<IRedisClient>(serviceProvider => new AuthRedisClient(
                configuration.GetSection("MPAAuth:Redis").Get<AuthRedisOption>(),
                serviceProvider.GetRequiredService<ISerializer>()));

            services.AddSingleton<IMPAAuthStrategy>(serviceProvider => new MPAAuthSharedSessionStrategy(
                configuration.GetSection("MPAAuth").Get<MPASharedSessionOption>(),
                serviceProvider.GetRequiredService<IRedisClient>()));

            return services;
        }
    }
}