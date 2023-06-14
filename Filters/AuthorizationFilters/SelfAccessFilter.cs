using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace ModuleAssignment.Filters.AuthorizationFilters
{
    public class SelfAccessFilter : Attribute, IAuthorizationFilter
    {
        private readonly List<string> AllowedRoles;

        public SelfAccessFilter(params string[] allowedRoles)
        {
            AllowedRoles = allowedRoles.ToList();
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var Identity = context.HttpContext.User.Identity as ClaimsIdentity;

            if(AllowedRoles.Contains(Identity.FindFirst(Identity.RoleClaimType).Value))
            {
                if(Identity.FindFirst("empid").Value != context.HttpContext.Request.Query["id"])
                {
                    context.Result = new BadRequestObjectResult("Access Denied");
                }
            }
        }


    }
}
