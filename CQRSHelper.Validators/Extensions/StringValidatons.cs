using CQRSHelper.Validators.Interfaces;
using System.Linq;

namespace CQRSHelper.Validators.Extensions
{
    public static class StringValidatons
    {
        public static IProperty<string> HasMaxLength(this IProperty<string> property, int maxLength, params string[] messages) => 
            property.AddValidationRule(x => x is string value && value.Length > maxLength ? messages : Enumerable.Empty<string>());

        public static IProperty<string> HasMinLength(this IProperty<string> property, int minLength, params string[] messages) => 
            property.AddValidationRule(x => x is string value && value.Length < minLength ? messages : Enumerable.Empty<string>());

        public static IProperty<string> HasLengthRange(this IProperty<string> property, int minLength, int maxLength, params string[] messages) => 
            property.AddValidationRule(x => x is string value && value.Length < minLength || x.Length > maxLength ? messages : Enumerable.Empty<string>());

        public static IProperty<string> IsNotNullOrEmpty(this IProperty<string> property, params string[] messages) => 
            property.AddValidationRule(x => string.IsNullOrEmpty(x) ? messages : Enumerable.Empty<string>());
    }
}
