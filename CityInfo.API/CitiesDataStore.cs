using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "Rio de Janeiro",
                    Description = "Morre-se rapidamente",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Cristo Redentor",
                            Description = "Ótimo local para assaltos"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2, 
                            Name = "Rocinha",
                            Description = "Biggest favela in the world"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "São Paulo",
                    Description = "Não muito diferente",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "...",
                            Description = "Difícil achar um..."
                        }
                    }
                }
            };
        }
    }
}
