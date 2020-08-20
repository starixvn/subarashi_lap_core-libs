using Fanex.Core.Authentication.Abstractions;
using System;

namespace Fanex.Core.Authentication.Services
{
    public abstract class BaseAuthInfoService<TAuthInfo>
        where TAuthInfo : class, IAuthInfo
    {
        private readonly Lazy<TAuthInfo> _lazyAuthInfo;
        protected TAuthInfo AuthInfo => _lazyAuthInfo.Value;

        protected BaseAuthInfoService(object data)
        {
            _lazyAuthInfo = new Lazy<TAuthInfo>(() =>
            {
                return data as TAuthInfo ?? throw new Exception("AuthInfo is null");
            });
        }
    }
}