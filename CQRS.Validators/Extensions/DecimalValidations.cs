using CQRS.Validators.Interfaces;
using System.Linq;

namespace CQRS.Validators.Extensions
{
    public static class DecimalValidations
    {
        public static IProperty<decimal> IsInRange(this IProperty<decimal> property, decimal begin, decimal end, params string[] message) => 
            property.AddValidationRule(x => x < begin || x > end ? message : Enumerable.Empty<string>());

        public static IProperty<decimal> HasMaxValue(this IProperty<decimal> property, decimal max, params string[] message) =>
            property.AddValidationRule(x => x > max ? message : Enumerable.Empty<string>());

        public static IProperty<decimal> HasMinValue(this IProperty<decimal> property, decimal min, params string[] message) =>
            property.AddValidationRule(x => x < min ? message : Enumerable.Empty<string>());

    }
}
