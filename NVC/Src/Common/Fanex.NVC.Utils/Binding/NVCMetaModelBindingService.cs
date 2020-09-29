using Fanex.Core.Utils;
using System.Collections.Generic;

namespace Fanex.NVC.Utils
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