using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CitiesController: ControllerBase
	{
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityInfoRepository cityInfoRepository,
			IMapper mapper)
		{
            _cityInfoRepository = cityInfoRepository ??
				throw new ArgumentNullException(nameof(cityInfoRepository));
			_mapper = mapper ??
                throw new ArgumentNullException(nameof(cityInfoRepository));
        }

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities()
		{
			var cityEntities = await _cityInfoRepository.GetCitiesAsync();
			return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CityDto>> GetCity(int id)
		{
			// Find City
			var cityToReturn = await _cityInfoRepository.GetCityAsync(id, false);

			if (cityToReturn == null)
			{
				return NotFound();
			}

			return Ok(cityToReturn);
		}
	}
}

