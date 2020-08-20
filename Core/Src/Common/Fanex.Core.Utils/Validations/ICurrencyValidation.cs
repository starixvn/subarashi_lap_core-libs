using System.Collections.Generic;

namespace Fanex.Core.Utils.Validations
{
    public interface ICurrencyValidation
    {
        bool IsValidBaseCurrency(string baseCurrency, bool isAllowEmpty = true);

        bool IsValidCurrency(int currencyId, IDictionary<int, string> currencyList);

        bool IsValidCurrencyList(string currencyIdList, IDictionary<int, string> currencyList);
    }
}