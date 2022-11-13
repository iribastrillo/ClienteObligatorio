using AppLayer.Interfaces;
using Cliente.Mapper;
using Cliente.Models.VMs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cliente.Controllers
{
    public class AuthController : Controller
    {
        private ILogin _UCLogin;
        private ISignUp _UCSignUp;
        private IAssignDefault _UCAssignDefault;

        public AuthController (ILogin UCLogin, ISignUp UCSignUp, IAssignDefault UCAssignDefault)
        {
            _UCLogin = UCLogin;
            _UCSignUp = UCSignUp;
            _UCAssignDefault = UCAssignDefault;
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
                return View("Index", "Home");
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return View("Index", "Home");
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
