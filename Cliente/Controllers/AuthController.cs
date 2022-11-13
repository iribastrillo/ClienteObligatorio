using AppLayer.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cliente.Controllers
{
    public class AuthController : Controller
    {
        private ILogin _UCLogin;

        public AuthController (ILogin UCLogin)
        {
            _UCLogin = UCLogin;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login (string username, string password)
        {
            try
            {
                User user = _UCLogin.DoLogin(username, password);
            } catch
            {
                throw new Exception("Usuario y/o contraseña inválidos.");
            }
            Console.WriteLine("Éxito!");
            return View("Index", "Home");
        }
    }
}
