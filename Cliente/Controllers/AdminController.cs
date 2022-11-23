using Cliente.Filters;
using Cliente.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;
using System.Text.Json;

namespace Cliente.Controllers
{
    [AdminOnly]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var client = new RestClient("https://localhost:44348/api/groupsstage");
            var request = new RestRequest();
            request.AddHeader("Contet-Type", "application/json");
            RestResponse response = client.ExecuteGet(request);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var groups = JsonSerializer.Deserialize<IEnumerable<GroupStageViewModel>>(response.Content, options);
            ViewBag.Groups = groups;

            client = new RestClient("https://localhost:44348/api/countries");
            request = new RestRequest();
            request.AddHeader("Contet-Type", "application/json");
            response = client.ExecuteGet(request);

            var countries = JsonSerializer.Deserialize<IEnumerable<CountryViewModel>>(response.Content, options);

            ViewBag.Countries = countries;

            client = new RestClient("https://localhost:44348/api/nationalteams/withoutgroup");
            request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            response = client.ExecuteGet(request);

            var ntWithoutGroup = JsonSerializer.Deserialize<IEnumerable<NationalTeamViewModel>>(response.Content, options);

            ViewBag.ntWithoutGroup = ntWithoutGroup;
            return View();
        }
    }
}
