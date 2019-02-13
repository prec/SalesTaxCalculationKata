using System;

namespace SalesTaxCalculationKata.Core.Extensions
{
    public static class MathExtensions
    {
        public static decimal RoundToNearestNickel(this decimal number)
        {
            return Math.Ceiling(number * 20) / 20;
        }
    }
}
