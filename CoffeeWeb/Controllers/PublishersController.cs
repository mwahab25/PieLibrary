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
    public class PublishersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Publisher> publishersList = new List<Publisher>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5003/api/publishers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    publishersList = JsonConvert.DeserializeObject<List<Publisher>>(apiResponse);
                }
            }
            return View(publishersList);
        }
    }
}
