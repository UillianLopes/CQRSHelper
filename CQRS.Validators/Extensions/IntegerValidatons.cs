using CQRSHelper.Core.Interfaces;
using CQRSHelper.Validators.Interfaces;
using System.Linq;

namespace CQRSHelper.Validators.Extensions
{
    public static class IntegerValidatons
    {
        public static IProperty<int> IsInRange(this IProperty<int> property, int begin, int end, params string[] message) =>
            property.AddValidationRule(x => x < begin || x > end ? message : Enumerable.Empty<string>());

        public static IProperty<int> HasMaxValue(this IProperty<int> property, decimal max, params string[] message) =>
            property.AddValidationRule(x => x > max ? message : Enumerable.Empty<string>());

        public static IProperty<int> HasMinValue(this IProperty<int> property, decimal min, params string[] message) =>
            property.AddValidationRule(x => x < min ? message : Enumerable.Empty<string>());
    }
}
