using CQRSHelper.Core.Defaults;
using CQRSHelper.Core.Interfaces;
using CQRSHelper.Mediator.Interfaces;
using CQRSHelper.Validators.Classes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSHelper.Mediator.Classes
{
    public class CommandMediator : ICommandMediator
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly CommandMediatorOptions _options;

        public CommandMediator(IServiceProvider serviceProvider, CommandMediatorOptions options)
        {
            _serviceProvider = serviceProvider;
            _options = options;
        }

        public ICommandResponse Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (Validate(command) is IEnumerable<string> messages && messages.Count() > 0)
                return new CommandResponse()
                {
                    Messages = messages,
                    Success = false
                };

            return GetCommandHandler<TCommand, ICommandResponse>().Handle(command);
        }

        public async Task<ICommandResponse> SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (Validate(command) is IEnumerable<string> messages && messages.Count() > 0)
                return new CommandResponse()
                {
                    Messages = messages,
                    Success = false
                };

            return await GetAsyncCommandHandlers<TCommand>().Handle(command);
        }
            
        private IEnumerable<string> Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (_options.ValidatorsTypes is ICollection<Type> validatorsTypes)
                if (validatorsTypes.Where(x => x.BaseType == typeof(CommandValidator<TCommand>)).FirstOrDefault() is Type validator)
                    return (Activator.CreateInstance(validator) as CommandValidator<TCommand>).Validate(command);

            return null;
        }

        private ICommandHandlerAsync<TCommand> GetAsyncCommandHandlers<TCommand>() where TCommand : ICommand => 
            _serviceProvider.GetService<ICommandHandlerAsync<TCommand>>();

        private ICommandHandler<TCommand> GetCommandHandler<TCommand, TCommandResponse>() where TCommand : ICommand => 
            _serviceProvider.GetService<ICommandHandler<TCommand>>();

    }
}
