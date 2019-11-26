using System.Collections.Generic;

namespace ExchangeRates.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsNotNull(this object o)
        {
            return o != null;
        }

        public static bool IsValid(this KeyValuePair<string, double> o)
        {
            if (!o.Key.IsNotNull())
            {
                return false;
            }

            if (o.Value <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
