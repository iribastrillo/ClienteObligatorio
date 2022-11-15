using Cliente.Models.DTOs;
using Cliente.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cliente.Controllers
{
    public class NationalTeamController : Controller
    {
        public IActionResult Create(AdminViewModel admin)
        {
            var client = new RestClient("https://localhost:44348/api/nationalteams");
            var request = new RestRequest();

            NationalTeamDTO nationalTeam = new NationalTeamDTO
            {
                Country = new CountryDTO (admin.CountryId),
                Name = admin.Name,
                Phone = admin.Phone,
                Email = admin.Email,
                Bettors = 0
            };

            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonSerializer.Serialize(nationalTeam));
            var response = client.Post(request);

            return RedirectToAction("Index", "Admin");
        }
    }
}
