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

        public CitiesController(ICityInfoRepository cityInfoRepository)
		{
            _cityInfoRepository = cityInfoRepository ??
				throw new ArgumentNullException(nameof(cityInfoRepository));
        }

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCities()
		{
			var cityEntities = await _cityInfoRepository.GetCitiesAsync();
			var result = new List<CityWithoutPointsOfInterestDto>();
			foreach (var cityEntity in cityEntities)
			{
				result.Add(new CityWithoutPointsOfInterestDto
				{
					Id = cityEntity.Id,
					Name = cityEntity.Name,
					Description = cityEntity.Description
				});
			}
			return Ok(result);
		}

		[HttpGet("{id}")]
		public ActionResult<CityDto> GetCity(int id)
		{
			// Find City
			//var cityToReturn = _citiesDataStore.Cities
			//	.FirstOrDefault(city => city.Id == id);

			//if (cityToReturn == null)
			//{
			//	return NotFound();
			//}

			//         return Ok(cityToReturn);
			return Ok();
		}
	}
}

