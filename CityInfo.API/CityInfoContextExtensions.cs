using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;

namespace CityInfo.API
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

            var cities = new List<City>()
            {
                new City()
                {
                    Name = "Rio de Janeiro",
                    Description = "Cidade maravilhosa",
                    PointOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Cristo Redentor",
                            Desciption = "Aquele famoso no mundo inteiro"
                        },
                        new PointOfInterest()
                        {
                            Name = "Pão de açucar",
                            Desciption = "Aquele dos bondinhos"
                        }
                    }
                },
                new City()
                {
                    Name = "São Paulo",
                    Description = "Terra da garoa",
                    PointOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Ponte Octávio Frias de Oliveira",
                            Desciption =
                                "A única ponte estaiada do mundo com duas pistas em curva conectadas a um mesmo mastro"
                        }
                    }
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
