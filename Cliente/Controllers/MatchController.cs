using Cliente.Models.DTOs;
using Cliente.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cliente.Controllers
{
    public class MatchController : Controller
    {
        public IActionResult Create (AdminViewModel admin)
        {
            MatchDTO match = new MatchDTO
            {
                HomeId = admin.HomeId,
                AwayId = admin.AwayId,
                MatchDate = new DateTime (2022, admin.Month, admin.Day, admin.Hour, 0, 0)
            };
            Console.Write(match);
            return View();
        }
    }
}
