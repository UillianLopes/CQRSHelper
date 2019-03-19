using CQRS.Core.Interfaces;
using CQRS.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CQRS.Validators.Classes
{
    public abstract class CommandValidator<TCommand> where TCommand : ICommand
    {
        private List<IProperty> Properties { get; set; }

        protected CommandValidator()
        {
            Properties = new List<IProperty>();
        }

        protected IProperty<TType> Property<TType>(Expression<Func<TCommand, TType>> propertyExpression)
        {
            var expression = (MemberExpression)propertyExpression.Body;
            var member = expression.Member;
            var name = member.Name;
            var property = new Property<TType>(name);
            Properties.Add(property);
            return property;
        }

        public IEnumerable<string> Validate(TCommand command)
        {
            return Properties.SelectMany(x => x.Validate(command));
        }
    }
}
