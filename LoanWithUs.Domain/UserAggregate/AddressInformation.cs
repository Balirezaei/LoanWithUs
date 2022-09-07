namespace LoanWithUs.Domain.UserAggregate
{
    public class AddressInformation
    {
        protected AddressInformation() { }
        public int ProvinceId { get; private set; }
        public int CityId { get; private set; }
        public string PostalCode { get; private set; }
        public string HomeAddress { get; private set; }
        public string HomePhone { get; private set; }
        public string WorkAddress { get; private set; }
        public string WorkPhone { get; private set; }
    }
}