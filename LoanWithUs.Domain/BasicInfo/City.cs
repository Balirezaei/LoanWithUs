using LoanWithUs.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Domain
{
    public  class City
    {
        protected City() { }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ProvinceId { get; set; }
        public City? Province { get; set; }
        public List<City> Cities { get; set; }
        //public List<AddressInformation> CityAddressInformations { get; set; }
        //public List<AddressInformation> ProvinceAddressInformations { get; set; }
        /// <summary>
        /// پیش شماره تلفن ثابت
        /// </summary>
        public string PrefixNumber { get; set; }

        public City(int id, string title, int? provinceId, List<City> cities, string prefixNumber)
        {
            Id = id;
            Title = title;
            ProvinceId = provinceId;
            Cities = cities;
            PrefixNumber = prefixNumber;
        }
    }
}
