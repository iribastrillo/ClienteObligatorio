using Cliente.Filters;
using Cliente.Models.VMs;
using Cliente.Models.VMs.Errors;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Cliente.Controllers
{
    public class SearchController : Controller
    {
        [AdminOrBettorOnly]
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
        [LoggedInOnly]
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
        [LoggedInOnly]
        public IActionResult ByNationalTeamName(string query)
        {
            var client = new RestClient("https://localhost:44348/api/match/byCountryName/" + query);
            var request = new RestRequest();
            request.AddParameter("countryName", query);
            request.AddHeader("Content-Type", "application/json");

            RestResponse rResponse = client.ExecuteGet(request);
            if(rResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return View("BadRequestError", new BadRequestViewModel { Message = rResponse.Content });
            }

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
        [AdminOrBettorOnly]
        public IActionResult BetweenDates(DateTime fromDate, DateTime toDate)
        {
            string fromStr = fromDate.ToString("yyyy-MM-dd");
            string toStr = toDate.ToString("yyyy-MM-dd");
            string url = $"https://localhost:44348/api/match/FromDate/{fromStr}/ToDate/{toStr}";
            var client = new RestClient(url);
            var request = new RestRequest();
            var param = new {
                fromDate = fromStr,
                toDate = toStr
            };
            request.AddObject(param);
            request.AddHeader("Content-Type", "application/json");
            try
            {
                var response = client.Get(request);
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                if(response.Content == null)
                {
                    return View("NoResults");
                }
                var matches = JsonSerializer.Deserialize < IEnumerable<MatchViewModel>>(response.Content, options);
                return View("Results", matches);
            }
            catch
            {
                return View("NoResults");
            }


        }
    }
}
