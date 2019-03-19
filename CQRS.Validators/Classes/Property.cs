using CQRSHelper.Core.Interfaces;
using CQRSHelper.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRSHelper.Validators.Classes
{
    public class Property<TType> : IProperty<TType>
    {
        private List<IValidationRule<TType>> Rules { get; set; }

        private string Name { get; set; }

        public Property(string name)
        {
            Name = name;
            Rules = new List<IValidationRule<TType>>();
        }

        public IEnumerable<string> Validate(ICommand command)
        {
            var type = command.GetType();
            var property = type.GetProperty(Name);
            var value = (TType)property.GetValue(command);
            return Rules.SelectMany(x => x.Validate(value));
        }

        public IProperty<TType> AddValidationRule(Func<TType, IEnumerable<string>> validation)
        {
            Rules.Add(new ValidationRule<TType>(validation));
            return this;
        }

        public IProperty<TType> AddValidationRule(Func<TType, string[]> validation)
        {
            Rules.Add(new ValidationRule<TType>(validation));
            return this;
        }

    }
}
