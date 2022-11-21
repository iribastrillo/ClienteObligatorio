using Cliente.Models.DTOs;
using Cliente.Models.VMs;
using Cliente.Models.VMs.Errors;
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

            GroupStageDTO groupStage = new GroupStageDTO (admin.Group);

            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonSerializer.Serialize(groupStage));
            RestResponse response = client.ExecutePost(request);

            if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return View ("BadRequestError", new BadRequestViewModel { Message = response.Content });
            }

            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Delete(int id, string group)
        {
            var client = new RestClient("https://localhost:44348/api/groupsstage/" + id);
            var request = new RestRequest();

            GroupStageDTO groupStage = new GroupStageDTO(id, group);

            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonSerializer.Serialize(groupStage));
            var response = client.Delete(request);
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Edit(int id, string group)
        {
            GroupStageDTO groupStage = new GroupStageDTO(id, group);
            return View(groupStage);
        }
        [HttpPost]
        public IActionResult Update (int id, string group)
        {
            var client = new RestClient("https://localhost:44348/api/groupsstage");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(JsonSerializer.Serialize(new GroupStageDTO(id, group)));
            RestResponse response = client.ExecutePut(request);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return View("BadRequestError", new BadRequestViewModel { Message = response.Content });
            }
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult GetTableByBroup(string group)
        {
            var client = new RestClient("https://localhost:44348/api/groupsStage/byGroup/" + group);
            var request = new RestRequest();

            request.AddParameter("groupName", group);
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
                var nts = JsonSerializer.Deserialize<IEnumerable<TableGroupNTsViewModel>>(response.Content, options);
                return View("ByGroup", nts);
            }
            return View("BadRequestError", new BadRequestViewModel { Message = rResponse.Content });
        }

    }
}

