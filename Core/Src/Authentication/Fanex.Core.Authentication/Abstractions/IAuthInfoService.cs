using System.Collections.Generic;

namespace Fanex.Core.Authentication
{
    public interface IAuthInfoService
    {
        int LicenseeId { get; }
        string LicenseeName { get; }
        string Language { get; }
        IDictionary<int, string> CurrencyList { get; }
        IDictionary<int, int[]> CurrencyAgentList { get; }
        bool IsAllowedCustomerComm { get; }
    }
}