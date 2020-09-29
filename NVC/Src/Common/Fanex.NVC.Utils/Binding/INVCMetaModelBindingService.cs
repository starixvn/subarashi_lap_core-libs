using Fanex.Core.Utils;
using System.Collections.Generic;

namespace Fanex.NVC.Utils
{
    public interface INVCMetaModelBindingService : IMetaModelBindingService
    {
        void BindLicenseeId(IDictionary<string, object> actionArguments, int licenseeId);
    }
}