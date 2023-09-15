using System.Web;
using System.Web.Routing;

namespace WebMVC
{
    public class RoutingConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, 
            Route route, string parameterName, RouteValueDictionary values, 
            RouteDirection routeDirection)
        {
            //Implementer la logique de la contrainte 
            return (int.TryParse(values[parameterName].ToString(),
                out int resultat) && (resultat % 2 == 0));
        }
    }
}