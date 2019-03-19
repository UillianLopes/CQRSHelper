using CQRSHelper.Core.Interfaces;
using CQRSHelper.Validators.Classes;
using CQRSHelper.Validators.Interfaces;
using System.Linq;

namespace CQRSHelper.Validators.Extensions
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
