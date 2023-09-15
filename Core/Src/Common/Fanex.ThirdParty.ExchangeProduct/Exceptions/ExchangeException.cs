using System;
using System.Runtime.Serialization;

namespace Fanex.ThirdParty.ExchangeProduct.Exceptions
{
    [Serializable]
    public class ExchangeException : Exception
    {
        public ExchangeException(string msg) : base(msg) { }

        public ExchangeException(string msg, Exception innerException) : base(msg, innerException) { }

        protected ExchangeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
                {
                }
    }
}
