using MediatR;

namespace LoanWithUs.ApplicationService.Contract
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ProvinceId { get; set; }
    }

    public class GetCityQuery : IRequest<List<CityDto>>
    {
        public int? ParentProvince { get; set; }
    }
}