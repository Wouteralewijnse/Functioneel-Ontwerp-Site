using Functioneel_Ontwerp_Site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;
using Functioneel_Ontwerp_Site.Database;

namespace Functioneel_Ontwerp_Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Festival> products;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            // lijst met producten ophalen
            var products = GetAllProducts();

            // de lijst met producten in de html stoppen
            return View(products);
        }

        public List<Festival> GetAllProducts()
        {
            // alle producten ophalen
            var rows = DatabaseConnector.GetRows("select * from festival");

            // lijst maken om alle namen in te stoppen
            List<Festival> products = new List<Festival>();

            foreach (var row in rows)
            {
                Festival p = new Festival();
                p.Naam = row["naam"].ToString();
                p.Beschrijving = row["beschrijving"].ToString();
                p.Afbeelding = row["Afbeelding"].ToString();
                p.Id = Convert.ToInt32(row["id"]);

                products.Add(p);
            }

            // de lijst met namen in de html stoppen
            return products;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("contact")]
        public IActionResult Contact(Person person)
        {
            if (ModelState.IsValid)
                return Redirect("/succes");

            return View(person);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

