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
            var response = client.Get(request);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var groups = JsonSerializer.Deserialize<IEnumerable<GroupStageViewModel>>(response.Content, options);
            ViewBag.Groups = groups;

            return View();
        }
    }
}
