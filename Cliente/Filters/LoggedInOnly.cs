using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace Cliente.Filters
{
    public class LoggedInOnly : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.GetString ("role") == null)
            {
                context.Result = new RedirectToActionResult("Index", "Auth", new {});
            }
        }
    }
}
