using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fanex.Core.Utils
{
    public static class SystemConstants
    {
        public const int SheetSizeExcel = 65000;

        public const int MaxDataTotalRow = int.MaxValue - 1000;

        public static readonly int MinBaseCurrencyType = BaseCurrencyType.INH;

        public static readonly ReadOnlyCollection<string> BaseCurrencyListOfSummaryTotalRow = new ReadOnlyCollection<string>(
         new List<string> { "EUR", "USD", "GBP" });

        public static readonly IDictionary<int, string> BaseCurrencyList = new Dictionary<int, string> {
            { BaseCurrencyType.Eur,"EUR" },
            { BaseCurrencyType.Usd,"USD" },
            { BaseCurrencyType.Gbp,"GBP" },
            { BaseCurrencyType.MYR,"MYR" },
            { BaseCurrencyType.CNY,"CNY" },
            { BaseCurrencyType.THB,"THB" },
            { BaseCurrencyType.IDR,"IDR" },
            { BaseCurrencyType.INH,"INH" },
        };
    }
}