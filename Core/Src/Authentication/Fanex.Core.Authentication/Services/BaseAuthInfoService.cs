using System;

namespace Fanex.Core.Authentication
{
    public abstract class BaseAuthInfoService<TAuthInfo>
        where TAuthInfo : class
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

        protected BaseAuthInfoService(TAuthInfo data)
        {
            _lazyAuthInfo = new Lazy<TAuthInfo>(() =>
            {
                return data;
            });
        }
    }
}