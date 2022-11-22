using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Cliente.Filters
{
    public class AdminOrBettorOnly : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string role = context.HttpContext.Session.GetString("role");
            if (role != "Admin" || role != "Apostador")
            {
                context.Result = new RedirectToActionResult("Index", "Home", new { });
            }
        }
    }
}
