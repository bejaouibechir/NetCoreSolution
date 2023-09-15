using System.Diagnostics;

namespace WebMiddleWareApp
{
    public class MonMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;
        public MonMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //Debut de traitement de requêtes
            Debug.WriteLine($"Traitement de requête à {DateTime.Now}");
            //Fin de traitement de requêtes

            await _next(context);

            //Debut de traitement de reponses
            Debug.WriteLine($"Traitement de réponse à {DateTime.Now}");
            //Fin de traitement de reponses


        }
    }
}
