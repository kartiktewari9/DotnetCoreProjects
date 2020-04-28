using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent:ViewComponent
    {
        private readonly IResturantData resturantData;

        public RestaurantCountViewComponent(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = resturantData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
