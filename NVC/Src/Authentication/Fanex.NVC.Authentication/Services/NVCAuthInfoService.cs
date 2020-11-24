using Fanex.Core.Authentication;
using Fanex.NVC.Authentication.Infrastructure;

#if NET461
using System.Collections;
#endif

using System.Collections.Generic;

namespace Fanex.NVC.Authentication
{
    public class NVCAuthInfoService : BaseAuthInfoService<NVCAuthInfo>, INVCAuthInfoService
    {
#if NET461
        public NVCAuthInfoService(IDictionary contextData)
            : base(contextData.Contains(NVCAuthSchema.NVCSharedAuth) ? contextData[NVCAuthSchema.NVCSharedAuth] : null)
        {
        }
#endif

#if NETCORE

        public NVCAuthInfoService(IDictionary<object, object> contextData)
            : base(contextData.ContainsKey(NVCAuthSchema.NVCSharedAuth) ? contextData[NVCAuthSchema.NVCSharedAuth] : null)
        {
        }

#endif

        public int LicenseeId => AuthInfo.LicenseeAuthInfo.LicenseeId;
        public IEnumerable<NVCFunctionAuthInfo> FunctionList => AuthInfo.UserAuthInfo.FunctionList;
        public string LicenseeName => AuthInfo.LicenseeAuthInfo.LicenseeName;
        public string Language => AuthInfo.UserAuthInfo.Language;
        public IDictionary<int, string> CurrencyList => AuthInfo.UserAuthInfo.CurrencyList;
        public IDictionary<int, int[]> CurrencyAgentList => AuthInfo.UserAuthInfo.CurrencyAgentList;
        public IEnumerable<Brand> BrandList => AuthInfo.UserAuthInfo.BrandList;
        public bool IsAllowedCustomerComm => AuthInfo.LicenseeAuthInfo.IsAllowedCustomerComm;
        public bool IsLicenseeUser => AuthInfo.UserAuthInfo.IsLicenseeUser;
    }
}