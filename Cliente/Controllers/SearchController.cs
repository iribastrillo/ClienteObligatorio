using Cliente.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;
using System.Text.Json;

namespace Cliente.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult ByGroup (string name)
        {
            var client = new RestClient("https://localhost:44348/api/Match/ByGroupName/" + name);
            var request = new RestRequest();
            request.AddParameter("Name", name);
            request.AddHeader("Contet-Type", "application/json");
            try
            {
                var response = client.Get(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };

                if (response.Content != null)
                {
                    var matches = JsonSerializer.Deserialize<IEnumerable<MatchViewModel>>(response.Content, options);
                    return View("Results", matches);
                } else
                {
                    return View("NoResults");
                }
            }
            catch
            {
                return View("NoResults");
            }     
        }

        public IActionResult ByIso(string query)
        {
            var client = new RestClient("https://localhost:44348/api/match/byCountryISO/" + query);
            var request = new RestRequest();
            request.AddParameter("countryISO", query);
            request.AddHeader("Content-Type", "application/json");

            try
            {
                var response = client.Get(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };

                if(response.Content != null)
                {
                    var matches = JsonSerializer.Deserialize<IEnumerable<MatchViewModel>>(response.Content, options);
                    return View("Results", matches);
                }
                return View("NoResults");
            }
            catch
            {
                return View("NoResults");
            } 

        }
    }
}
