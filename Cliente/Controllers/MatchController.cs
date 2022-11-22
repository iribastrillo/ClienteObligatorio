using Cliente.Filters;
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
    [AdminOnly]
    public class MatchController : Controller
    {
        [HttpPost]
        public IActionResult Create (AdminViewModel admin)
        {
            var client = new RestClient("https://localhost:44348/api/match");
            var request = new RestRequest();
            DateTime dateTime;

            try
            {
                dateTime = new DateTime(2022, admin.Month, admin.Day, admin.Hour, 0, 0);
            } catch
            {
                return View("BadRequestError", new BadRequestViewModel { Message = "Debes ingresar una fecha válida." });
            }

            MatchDTO match = new MatchDTO
            {
                HomeId = admin.HomeId,
                AwayId = admin.AwayId,
                MatchDate = new DateTime (2022, admin.Month, admin.Day, admin.Hour, 0, 0)
            };

            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonSerializer.Serialize(match));

            RestResponse response = client.ExecutePost(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return View("BadRequestError", new BadRequestViewModel { Message = response.Content });
            }

            return RedirectToAction("Index", "Admin");
        }
    }
}
