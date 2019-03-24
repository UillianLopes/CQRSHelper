using CQRSHelper.Validators.Interfaces;
using System.Linq;

namespace CQRSHelper.Validators.Extensions
{
    public static class IntegerValidatons
    {
        public static IProperty<int> IsInRange(this IProperty<int> property, int begin, int end, params string[] messages) =>
            property.AddValidationRule(x => x < begin || x > end ? messages : Enumerable.Empty<string>());

        public static IProperty<int> HasMaxValue(this IProperty<int> property, decimal max, params string[] messages) =>
            property.AddValidationRule(x => x > max ? messages : Enumerable.Empty<string>());

        public static IProperty<int> HasMinValue(this IProperty<int> property, decimal min, params string[] messages) =>
            property.AddValidationRule(x => x < min ? messages : Enumerable.Empty<string>());
    }
}
