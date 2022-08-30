using RestaurantManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManagement.Data
{
    public interface IRestaurantData
    {
        public IEnumerable<Restaurant> GetRestaurantByName(string name = null);

        public Restaurant GetRestaurantById(int id);
    }

    public class InMemoryRestaurant : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurant()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant() { Id = 1, Name = "Dara's Dhaba", Location = "Mira Road", Cuisine = CuisineType.Indian },
                new Restaurant() { Id = 2, Name = "La Pino'z", Location = "Mira Road", Cuisine = CuisineType.Italian },
                new Restaurant() { Id = 3, Name = "Sai Dhaba", Location = "Dahisar", Cuisine = CuisineType.Indian },
            };

        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)  
        {
            return from r in restaurants
                   where string.IsNullOrWhiteSpace(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);
        }
    }
}
