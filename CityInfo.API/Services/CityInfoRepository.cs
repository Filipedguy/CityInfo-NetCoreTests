﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }

        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId, false);

            city.PointOfInterest.Add(pointOfInterest);
        }

        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            var query = _context.Cities.Where(c => c.Id == cityId);

            if (includePointsOfInterest)
            {
                query = query.Include(c => c.PointOfInterest);
            }

            return query.FirstOrDefault();
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointOfInterests.Where(p => p.CityId == cityId && p.Id == pointOfInterestId).FirstOrDefault();
        }

        public IEnumerable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointOfInterests.Where(p => p.CityId == cityId).ToList();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
