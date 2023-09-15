internal class RoutingConstraint :IRouteConstraint
{
    public RoutingConstraint()
    {

    }

    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        //Implementer la logique de la contrainte 
        return (int.TryParse(values[routeKey].ToString(),
            out int resultat) && (resultat % 2 == 0));
    }
}