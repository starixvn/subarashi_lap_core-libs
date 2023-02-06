using Fanex.Core.Utils.Models.DTO;

namespace Fanex.Core.Utils.Service.Interfaces
{
    public interface IIpService
    {
        bool IsVNIP(string ipAddress);

        bool IsAlwaysIpvn(string ipAddress);

        Location GetIpLocation(string ipAddress, bool isShowIpvn = false);

        string GetIpAddress(string ipAddress, bool isShowIpvn = false);
    }
}