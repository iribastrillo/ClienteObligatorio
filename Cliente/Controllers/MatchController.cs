using Cliente.Models;
using Cliente.Models.DTOs;
using Cliente.Models.VMs;
using Cliente.Models.VMs.Errors;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Net.Http;
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

            try
            {
                RestResponse response = client.Post(request);
            } catch (HttpRequestException e)
            {
                BadRequestViewModel model = new BadRequestViewModel
                {
                    Message = e.Message
                };
                return View("BadRequestError", model);
            }
            
            return RedirectToAction("Index", "Admin");
        }
    }
}
