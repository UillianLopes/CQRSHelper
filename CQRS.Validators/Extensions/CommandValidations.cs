using CQRS.Core.Interfaces;
using CQRS.Validators.Classes;
using CQRS.Validators.Interfaces;
using System.Linq;

namespace CQRS.Validators.Extensions
{
    public static class CommandValidations
    {
        public static IProperty<TCommand> HasValidator<TCommand>(this IProperty<TCommand> property, CommandValidator<TCommand> validator) where TCommand : ICommand
        {
            property.AddValidationRule(x => x is TCommand command ? validator.Validate(command) : Enumerable.Empty<string>());
            return property;
        }
    }
}
