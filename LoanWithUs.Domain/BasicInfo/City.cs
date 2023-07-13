using LoanWithUs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanWithUs.Domain
{
    public  class City: BasicInfo
    {
        protected City() { }

        public string Title { get; set; }
        public int? ProvinceId { get; set; }
        public City? Province { get; set; }
        public ICollection<City> Cities { get; set; }
        //public ICollection<AddressInformation> CityAddressInformations { get; set; }
        //public ICollection<AddressInformation> ProvinceAddressInformations { get; set; }
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
