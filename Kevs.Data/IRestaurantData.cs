using Kevs.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kevs.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Kev's Pizza", Location = "Hamilton", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 1, Name = "Kev's Taco", Location = "Toronto", Cuisine = CuisineType.Mexican},
                new Restaurant {Id = 1, Name = "Kev's Dumplings", Location = "Waterloo", Cuisine = CuisineType.Chinese},
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
