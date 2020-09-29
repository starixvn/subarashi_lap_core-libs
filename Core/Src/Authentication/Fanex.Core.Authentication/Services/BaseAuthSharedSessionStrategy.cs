using System;

namespace Fanex.Core.Authentication
{
    public abstract class BaseAuthSharedSessionStrategy<TOptions>
        where TOptions : AuthSharedSessionOption
    {
        protected readonly ISessionClient _sessionClient;
        protected readonly TOptions _options;

        protected BaseAuthSharedSessionStrategy(TOptions options, ISessionClient sessionClient)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _sessionClient = sessionClient ?? throw new ArgumentNullException(nameof(sessionClient));
        }

        protected virtual string BuildKey(string token)
        {
            return "{" + _options.PrefixKey + "_" + token + "}_Data";
        }
    }
}