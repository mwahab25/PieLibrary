using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CoffeeWeb.Models;

namespace CoffeeWeb.Controllers
{
    public class AuthorsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Author> authorsList = new List<Author>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5003/api/authors"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    authorsList = JsonConvert.DeserializeObject<List<Author>>(apiResponse);
                }
            }
            return View(authorsList);
        }
    }
}
