using System;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
	public class CityInfoContext: DbContext
	{
		public DbSet<City> City { get; set; } = null!;

		public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;

		public CityInfoContext(DbContextOptions<CityInfoContext> options)
			: base(options)
		{

		}
	}
}

