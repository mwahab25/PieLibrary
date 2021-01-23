using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CoffeeWeb.Models;
using System.Net.Http;

namespace CoffeeWeb.Controllers
{
    public class ShelvesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Shelf> shelvesList = new List<Shelf>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5003/api/shelves"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    shelvesList = JsonConvert.DeserializeObject<List<Shelf>>(apiResponse);
                }
            }
            return View(shelvesList);
        }
    }
}
