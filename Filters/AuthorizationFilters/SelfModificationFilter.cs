using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace ModuleAssignment.Filters.AuthorizationFilters
{
    public class SelfModificationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var Identity = context.HttpContext.User.Identity as ClaimsIdentity;
            var test = Identity.FindFirst("empid").Value;
        }
    }
}
