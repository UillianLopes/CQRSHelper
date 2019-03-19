using CQRS.Validators.Interfaces;
using System;
using System.Collections.Generic;

namespace CQRS.Validators.Classes
{
    public class ValidationRule<T> : IValidationRule<T>
    {
        public Func<T, IEnumerable<string>> Validation { get; private set; }

        public ValidationRule(Func<T, IEnumerable<string>> validation) => Validation = validation;

        public IEnumerable<string> Validate(T value) 
        {
            return Validation(value);
        }
    }
}
