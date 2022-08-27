using RestaurantManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantManagement.Data
{
    public interface IRestaurantData
    {
        public IEnumerable<Restaurant> GetList();
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

        public IEnumerable<Restaurant> GetList()  
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
