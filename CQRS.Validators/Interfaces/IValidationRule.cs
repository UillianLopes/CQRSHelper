using System.Collections.Generic;

namespace CQRS.Validators.Interfaces
{
    public interface IValidationRule<T>
    {
        IEnumerable<string> Validate(T value);
    }
}
