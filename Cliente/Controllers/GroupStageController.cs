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
    public class GroupStageController : Controller
    {
        public IActionResult Create(AdminViewModel admin)
        {
            var client = new RestClient("https://localhost:44348/api/groupsstage");
            var request = new RestRequest();

            GroupStageDTO groupStage = new GroupStageDTO
            {
                Group = admin.Group
            };

            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonSerializer.Serialize(groupStage));
            var response = client.Post(request);

            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Delete (int id, string group)
        {
            var client = new RestClient("https://localhost:44348/api/groupsstage/" + id);
            var request = new RestRequest();

            GroupStageDTO groupStage = new GroupStageDTO
            {
                Group = group,
                Id = id
            };

            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonSerializer.Serialize(groupStage));
            var response = client.Delete(request);
            return RedirectToAction("Index", "Admin");
        }
    }
}
