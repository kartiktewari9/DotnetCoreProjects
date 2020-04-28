using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants
{
    public class DetailsModel : PageModel
    {
        private readonly IResturantData resturantData;

        public Resturant Resturant { get; set; }
        [TempData]
        public string Message { get; set; }

        public DetailsModel(IResturantData resturantData)
        {
            this.resturantData = resturantData;
        }
        public ActionResult OnGet(int resturantId)
        {
            Resturant = resturantData.GetById(resturantId);
            if (Resturant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}