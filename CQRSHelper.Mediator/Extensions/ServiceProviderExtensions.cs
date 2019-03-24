
using CQRSHelper.Mediator.Classes;
using CQRSHelper.Mediator.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CQRSHelper.Mediator.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddMediator(this IServiceCollection services, Action<CommandMediatorOptionsBuilder> configureOptions)
        {
            var optionsBuilder = new CommandMediatorOptionsBuilder();

            configureOptions(optionsBuilder);

            var options = optionsBuilder.Build();

            foreach (var handlerType in options.HandlerTypes)
            {
                foreach (var interfaceType in handlerType.GetInterfaces())
                {
                    services.AddScoped(interfaceType, handlerType);
                }
            }

            services.AddSingleton(options);
            services.AddScoped<ICommandMediator, CommandMediator>();
        }
    }
}
