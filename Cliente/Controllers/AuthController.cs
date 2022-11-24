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
        private IListAll _UCListAll;

        public AuthController (ILogin UCLogin, ISignUp UCSignUp, IAssignDefault UCAssignDefault, ICheck UCCheck, IListAll UCListAll)
        {
            _UCLogin = UCLogin;
            _UCSignUp = UCSignUp;
            _UCAssignDefault = UCAssignDefault;
            _UCCheck = UCCheck;
            _UCListAll = UCListAll;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login ()
        {
            ViewBag.ErrorMessage = "";
            ViewBag.Roles = _UCListAll.FindAll();
            return View();
        }
        [HttpPost]
        public IActionResult Login (string email, string password, int role)
        {
            ViewBag.Roles = _UCListAll.FindAll();
            try
            {
                User user = _UCLogin.DoLogin(email, password);
                Rol rol = _UCCheck.Check(role, user);
                HttpContext.Session.SetString("username", user.Username.Value);
                HttpContext.Session.SetString("role", rol.descriptor);
                return RedirectToAction("Index", "Home");
            } catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }     
        }

        public IActionResult Logout ()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Auth");
        }

        [HttpGet]
        public IActionResult SignUp ()
        {
            ViewBag.ErrorMessage = "";
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
                ViewBag.ErrorMessage = e.Message;
                return View();
            }

        }
    }
}
