using CQRSHelper.Core.Interfaces;
using CQRSHelper.Validators.Classes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRSHelper.Mediator.Classes
{
    public class CommandMediatorOptionsBuilder
    {
        private readonly ICollection<Type> _handlerTypes;
        private readonly ICollection<Type> _validatorsTypes;

        internal CommandMediatorOptionsBuilder()
        {
            _handlerTypes = new List<Type>();
            _validatorsTypes = new List<Type>();
        }

        public CommandMediatorOptionsBuilder AddHandlersOnAssemblyOf<T>()
        {
            var types = typeof(T)
                .Assembly
                .GetTypes()
                .Where(x => x.Namespace == typeof(T).Namespace && !x.FullName.Contains("+"));

            bool function(Type type)
            {
                var interfaces = types.SelectMany(x => x.GetInterfaces());

                var genericArguments = interfaces.SelectMany(x => x.GetGenericArguments());

                var genericArgumentsInterfaces = genericArguments.SelectMany(x => x.GetInterfaces());

                return (genericArguments.Contains(typeof(ICommandResponse)) && genericArgumentsInterfaces.Contains(typeof(ICommand))) || 
                    (genericArgumentsInterfaces.Contains(typeof(ICommand)) && genericArgumentsInterfaces.Contains(typeof(ICommandResponse)));
            }

            types = types
                .Where(function)
                .ToArray();

            foreach (var item in types)
            {
                if(_handlerTypes.Where(x => x.FullName == item.FullName).Count() <= 0)
                    _handlerTypes.Add(item);
            }

            return this;
        }

        public CommandMediatorOptionsBuilder AddValidatorsOnAssemblyOf<T>()
        {
            var types = typeof(T)
              .Assembly
              .GetTypes()
              .Where(x => x.Namespace == typeof(T).Namespace && 
                !x.FullName.Contains("+"));

            foreach(var item in types)
            {
                _validatorsTypes.Add(item);
            }

            return this;
        }

        internal CommandMediatorOptions Build()
        {
            return new CommandMediatorOptions
            {
                ValidatorsTypes = _validatorsTypes,
                HandlerTypes = _handlerTypes
            };
        }

    }
}
