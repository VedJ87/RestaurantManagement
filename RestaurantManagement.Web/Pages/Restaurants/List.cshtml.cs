using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using RestaurantManagement.Core;
using RestaurantManagement.Data;

namespace RestaurantManagement.Web.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        public string Messages { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Messages = config["Message"];
            Restaurants = restaurantData.GetRestaurantByName(SearchTerm);
        }
    }
}