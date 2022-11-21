using Cliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using RestSharp;
using System.Text.Json;
using Cliente.Models.VMs;
using System.Collections.Generic;
using Cliente.Filters;
using Cliente.Models.VMs.Errors;

namespace Cliente.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [LoggedInOnly]
        public IActionResult Index()
        {
            var client = new RestClient("https://localhost:44348/api/nationalteams");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            var response = client.Get(request);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var nationalTeams = JsonSerializer.Deserialize<IEnumerable<NationalTeamViewModel>>(response.Content, options);
            ViewBag.Response = nationalTeams;

            client = new RestClient("https://localhost:44348/api/groupsstage");
            response = client.Get(request);

            var groups = JsonSerializer.Deserialize<IEnumerable<GroupStageViewModel>>(response.Content, options);

            ViewBag.Groups = groups;

            return View();
        }

        [AdminOnly]
        public IActionResult Admin ()
        {
            return View();
        }


        public IActionResult Team()
        {
            return View();
        }

        public IActionResult BadRequest(BadRequestViewModel request)
        {
            return View(request);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
