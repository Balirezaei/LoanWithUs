namespace LoanWithUs.Domain
{
    public class AddressInformation
    {
        protected AddressInformation() { }

        internal AddressInformation(string province, int provinceId, int cityId, string city, string postalCode, string homeAddress, string homePhone, string workAddress, string workPhone)
        {
            Province = province;
            ProvinceId = provinceId;
            CityId = cityId;
            City = city;
            PostalCode = postalCode;
            HomeAddress = homeAddress;
            HomePhone = homePhone;
            WorkAddress = workAddress;
            WorkPhone = workPhone;
        }

        public string Province { get; set; }
        public int ProvinceId { get; private set; }
        public int CityId { get; private set; }
        public string City { get; set; }

        public string PostalCode { get; private set; }
        public string HomeAddress { get; private set; }
        public string HomePhone { get; private set; }
        public string WorkAddress { get; private set; }
        public string WorkPhone { get; private set; }

        internal void UpdateByNewValue(AddressInformation addressInformation)
        {
            Province = addressInformation.Province;
            ProvinceId = addressInformation.ProvinceId;
            CityId = addressInformation.CityId;
            City = addressInformation.City;
            PostalCode = addressInformation.PostalCode;
            HomeAddress = addressInformation.HomeAddress;
            HomePhone = addressInformation.HomePhone;
            WorkAddress = addressInformation.WorkAddress;
            WorkPhone = addressInformation.WorkPhone;
        }
    }

    public class AddressInformationBuilder
    {
        private string _province;
        private int _provinceId;
        private int _cityId;
        private string _city;
        private string _postalCode;
        private string _homeAddress;
        private string _homePhone;
        private string _workAddress;
        private string _workPhone;

        public AddressInformationBuilder WithHomeInfo(string postalCode, string homeAddress, string homePhone)
        {
            _postalCode = postalCode;
            _homeAddress = homeAddress;
            _homePhone = homePhone;
            return this;
        }

        public AddressInformationBuilder WithWorkInfo(string workAddress, string workPhone)
        {
            _workAddress = workAddress;
            _workPhone = workPhone;
            return this;
        }

        public AddressInformationBuilder WithCity(City city)
        {
            _province = city.Province.Title;
            _provinceId = city.ProvinceId ?? 0;
            _city = city.Title;
            _cityId = city.Id;
            return this;
        }

        public AddressInformation Build()
        {
            return new AddressInformation(_province, _provinceId, _cityId, _city, _postalCode, _homeAddress, _homePhone, _workAddress, _workPhone);
        }
    }
}