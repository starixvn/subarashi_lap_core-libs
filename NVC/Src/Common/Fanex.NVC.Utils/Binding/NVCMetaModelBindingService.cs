using Fanex.Core.Utils.Binding;
using Fanex.Core.Utils.Helpers;
using Fanex.Core.Utils.Models;
using System.Collections.Generic;

namespace Fanex.NVC.Utils.Binding
{
    public class NVCMetaModelBindingService : BaseMetaModelBindingService, INVCMetaModelBindingService
    {
        public void BindLicenseeId(IDictionary<string, object> actionArguments, int licenseeId)
        {
            if (MetaModelHelper.IsMetaModel(actionArguments, out ILicenseeIdMetaModel itemWithLicenseeId))
            {
                itemWithLicenseeId.LicenseeId = licenseeId;
            }
        }
    }
}