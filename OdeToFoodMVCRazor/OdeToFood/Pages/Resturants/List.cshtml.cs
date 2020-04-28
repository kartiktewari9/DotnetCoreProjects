using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Resturants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IResturantData resturantData;
        private readonly ILogger<ListModel> logger;
        public string Message;
        public IEnumerable<Resturant> Resturants;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config, IResturantData resturantData,ILogger<ListModel> logger)
        {
            this.config = config;
            this.resturantData = resturantData;
            this.logger = logger;
        }
        public void OnGet(string searchTerm)
        {
            logger.LogWarning("Executing get list of restaurants");
            Message = config["Message"];
            Resturants = resturantData.GetResturantsByName(SearchTerm);
        }
    }
}