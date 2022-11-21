using Cliente.Models.DTOs;
using Cliente.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

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
        public IActionResult Update (int id)
        {
            var client = new RestClient("https://localhost:44348/api/nationalteams/" + id);
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            var response = client.Get(request);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var team = JsonSerializer.Deserialize<NationalTeamViewModel>(response.Content, options);
            ViewBag.idNT = id;
            ViewBag.idCountry = team.idCountry;
            return View(team);
        }

        [HttpPost]
        public IActionResult Update(NationalTeamViewModel nt)
        {
            var client = new RestClient("https://localhost:44348/api/nationalteams");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonSerializer.Serialize(nt));
            var response = client.Put(request);
            return RedirectToAction("Index", "Admin");

        }
    }
}
