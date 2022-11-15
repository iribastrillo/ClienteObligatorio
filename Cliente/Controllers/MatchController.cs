using Cliente.Models.DTOs;
using Cliente.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Text.Json;

namespace Cliente.Controllers
{
    public class MatchController : Controller
    {
        [HttpPost]
        public IActionResult Create (AdminViewModel admin)
        {
            var client = new RestClient("https://localhost:44348/api/match");
            var request = new RestRequest();

            MatchDTO match = new MatchDTO
            {
                HomeId = admin.HomeId,
                AwayId = admin.AwayId,
                MatchDate = new DateTime (2022, admin.Month, admin.Day, admin.Hour, 0, 0)
            };

            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonSerializer.Serialize(match));
            var response = client.Post(request);

            Console.WriteLine(response.StatusCode);

            return RedirectToAction("Index", "Admin");
        }
    }
}
