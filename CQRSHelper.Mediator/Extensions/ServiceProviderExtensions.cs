
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

            foreach (var item in options.HandlerTypes)
            {
                foreach (var interfaceItem in item.GetInterfaces())
                {
                    services.AddScoped(interfaceItem, item);
                }
            }
            services.AddSingleton(options);
            services.AddScoped<ICommandMediator, CommandMediator>();
        }
    }
}
