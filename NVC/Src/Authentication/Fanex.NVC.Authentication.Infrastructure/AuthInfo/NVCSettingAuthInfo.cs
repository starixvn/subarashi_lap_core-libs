using System;

namespace Fanex.NVC.Authentication.Infrastructure
{
    [Serializable]
    public class NVCSettingAuthInfo
    {
        public string SettingKey { get; set; }

        public string SettingValue { get; set; }
    }
}