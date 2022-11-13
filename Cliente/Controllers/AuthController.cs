using AppLayer.Interfaces;
using Cliente.Mapper;
using Cliente.Models.VMs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cliente.Controllers
{
    public class AuthController : Controller
    {
        private ILogin _UCLogin;
        private ISignUp _UCSignUp;
        private IAssignDefault _UCAssignDefault;
        private ICheck _UCCheck;

        public AuthController (ILogin UCLogin, ISignUp UCSignUp, IAssignDefault UCAssignDefault, ICheck UCCheck)
        {
            _UCLogin = UCLogin;
            _UCSignUp = UCSignUp;
            _UCAssignDefault = UCAssignDefault;
            _UCCheck = UCCheck;
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
                Rol rol = _UCCheck.Check(user);
                HttpContext.Session.SetString("username", username);
                HttpContext.Session.SetString("role", rol.descriptor);
                return RedirectToAction("Index", "Home");
            } catch
            {
                return View();
            }     
        }

        public IActionResult Logout ()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignUp ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp (UserViewModel userVM)
        {
            try
            {
                User user = UserMapper.ToUser(userVM);
                _UCSignUp.SignUp(user);
                _UCAssignDefault.AssignDefaultRole(user);
                return View ("Index", "Auth");
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
