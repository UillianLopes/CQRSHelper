using System.Collections.Generic;

namespace CQRSHelper.Validators.Interfaces
{
    public interface IValidationRule<T>
    {
        IEnumerable<string> Validate(T value);
    }
}
