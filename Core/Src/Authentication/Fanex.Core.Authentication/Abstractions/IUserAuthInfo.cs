using System.Collections.Generic;

namespace Fanex.Core.Authentication.Abstractions
{
    public interface IUserAuthInfo { }

    public interface IUserAuthInfo<TFunction> : IUserAuthInfo
        where TFunction : IFunctionAuthInfo
    {
        int UserId { get; set; }

        string UserName { get; set; }

        string Language { get; set; }

        int OnUserId { get; set; }

        IEnumerable<TFunction> FunctionList { get; set; }

        IDictionary<int, string> CurrencyList { get; set; }

        IDictionary<int, int[]> CurrencyAgentList { get; set; }

        string DefaultBaseCurrency { get; set; }
    }
}