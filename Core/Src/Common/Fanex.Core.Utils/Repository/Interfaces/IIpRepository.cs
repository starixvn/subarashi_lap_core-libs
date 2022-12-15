using System;
using System.Collections.Generic;
using Fanex.Core.Utils.Models.DTO;

namespace Fanex.Core.Utils.Repository.Interfaces
{
    public interface IIpRepository
    {
        Tuple<IList<IPV4RangeEntity>, IList<IPV6RangeEntity>> GetVNIPs();

        Location GetIpLocation(string IPAddress);
    }
}