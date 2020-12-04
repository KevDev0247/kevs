using Kevs.Core;
using System.Collections.Generic;
using System.Linq;

namespace Kevs.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
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

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from r in restaurants 
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
