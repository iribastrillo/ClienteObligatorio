using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Cliente.Filters
{
    public class AdminOnly : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString("role") != "Admin")
            {
                context.Result = new RedirectToActionResult("Index", "Home", new { });
            }
        }
    }
}
