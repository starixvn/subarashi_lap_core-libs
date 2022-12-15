namespace Fanex.Core.Utils.Models.DTO
{
    public class Location
    {
        private string _countryCode;

        public string CountryCode
        {
            get => (string.IsNullOrEmpty(_countryCode) || _countryCode == "-") ? "N/A" : _countryCode;
            set => _countryCode = value;
        }

        private string _countryName;

        public string CountryName
        {
            get => (string.IsNullOrEmpty(_countryName) || _countryName == "-") ? "N/A" : _countryName;
            set => _countryName = value;
        }
    }
}