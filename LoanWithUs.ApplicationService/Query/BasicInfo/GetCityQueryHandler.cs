using AutoMapper;
using LoanWithUs.ApplicationService.Contract;
using LoanWithUs.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LoanWithUs.ApplicationService.Query.BasicInfo
{
    public class GetCityQueryHandler : IRequestHandler<GetCityQuery, List<CityDto>>
    {
        private readonly IGenericRepository<City> _cityRepository;
        private readonly IMapper _mapper;

        public GetCityQueryHandler(IGenericRepository<City> cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<List<CityDto>> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            List<City> cities;
            //if (request.ParentProvince == null)
            //{
            //    cities = await _cityRepository.GetAll().ToListAsync();

            //}
            //else
            //{
                cities = await _cityRepository.GetByPredicate(m => m.ProvinceId == request.ParentProvince).ToListAsync();
            //}
            return _mapper.Map<List<CityDto>>(cities);

        }
    }
}
