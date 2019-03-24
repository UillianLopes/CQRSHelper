using CQRSHelper.Validators.Interfaces;
using System.Linq;

namespace CQRSHelper.Validators.Extensions
{
    public static class GeneralValidatons
    {
        public static IProperty<TType> IsNotNull<TType>(this IProperty<TType> property, params string[] message) =>
            property.AddValidationRule(x => x == null ? message : Enumerable.Empty<string>());
    }
}
