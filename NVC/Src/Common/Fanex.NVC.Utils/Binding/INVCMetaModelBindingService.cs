using Fanex.Core.Utils.Binding;
using System.Collections.Generic;

namespace Fanex.NVC.Utils.Binding
{
    public interface INVCMetaModelBindingService : IMetaModelBindingService
    {
        void BindLicenseeId(IDictionary<string, object> actionArguments, int licenseeId);
    }
}