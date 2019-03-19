using CQRS.Core.Interfaces;
using CQRS.Validators.Classes;
using System;
using System.Collections.Generic;

namespace CQRS.Validators.Interfaces
{
    public interface IProperty
    {
        IEnumerable<string> Validate(ICommand value);
    }

    public interface IProperty<TType> : IProperty
    {
        IProperty<TType> AddValidationRule(Func<TType, IEnumerable<string>> validation);
    }
}
