using System;
using System.Collections.Generic;
using System.Linq;

namespace Fanex.Core.Utils
{
    public class CurrencyValidation : ICurrencyValidation
    {
        public bool IsValidBaseCurrency(string baseCurrency, bool isAllowEmpty = true)
        {
            return (isAllowEmpty && string.IsNullOrEmpty(baseCurrency))
                || SystemConstants.BaseCurrencyList
                       .Any(x => x.Value.Equals(baseCurrency, StringComparison.OrdinalIgnoreCase));
        }

        public bool IsValidCurrency(int currencyId, IDictionary<int, string> currencyList)
        {
            return (currencyId < 0 && currencyId >= SystemConstants.MinBaseCurrencyType)
                          || currencyId == BaseCurrencyType.All || currencyList.ContainsKey(currencyId);
        }

        public bool IsValidCurrencyList(string currencyIdList, IDictionary<int, string> currencyList)
        {
            if (string.IsNullOrEmpty(currencyIdList))
            {
                return false;
            }

            var items = currencyIdList.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return !items.Any(x => !int.TryParse(x, out int n) || !currencyList.ContainsKey(n));
        }
    }
}