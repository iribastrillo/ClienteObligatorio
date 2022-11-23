using Cliente.Filters;
using Cliente.Models.DTOs;
using Cliente.Models.VMs;
using Cliente.Models.VMs.Errors;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net.Http;
using System.Text.Json;

namespace Cliente.Controllers
{
    [AdminOnly]
    public class NationalTeamController : Controller
    {
        public IActionResult Create(AdminViewModel admin)
        {
            var client = new RestClient("https://localhost:44348/api/nationalteams");
            var request = new RestRequest();

            NationalTeamViewModel nationalTeam = new NationalTeamViewModel
            {
                idCountry = admin.CountryId,
                name = admin.Name,
                phone  = admin.Phone,
                email = admin.Email,
                bettors = admin.Bettors
            };

            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonSerializer.Serialize(nationalTeam));
            RestResponse response = client.ExecutePost(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return View("BadRequestError", new BadRequestViewModel { Message = "Debes ingresar datos vállidos."});
            }

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
        public IActionResult GetById(int idNT)
        {
            var client = new RestClient("https://localhost:44348/api/nationalteams/" + idNT);
            var request = new RestRequest();

            request.AddHeader("Content-Type", "application/json");

            RestResponse rResponse = client.ExecuteGet(request);
            if (rResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return View("BadRequestError", new BadRequestViewModel { Message = rResponse.Content });
            }

            var response = client.Get(request);

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var nt = JsonSerializer.Deserialize<NationalTeamViewModel>(response.Content, options);

            return View(nt);
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

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var client = new RestClient("https://localhost:44348/api/nationalteams/" + id);
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            RestResponse response;
            try
            {
                response = client.Delete(request);
            } catch
            {
                return View("BadRequestError", new BadRequestViewModel { Message = "No puedes eliminar un equipo que está en un grupo o tiene partidos asignados." });
            }
            
            return RedirectToAction("Index", "Admin");
        }
    }
}
