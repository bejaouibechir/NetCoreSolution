using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMVCore.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAdmin = context.HttpContext.User.IsInRole("Administrator");
            if (!isAdmin)
            {
               //Empêcher l'utilisateur de continuer à neviguer 
               //vers la ressource
                context.Result = new ForbidResult();
            }
        }
    }
}
