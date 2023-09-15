using System.Diagnostics;

namespace WebMiddleWareApp
{
    static public class MiddewareExtensions
    {
        static public void UseMiddleware1(this  WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                Debug.WriteLine($"Middleware1: Traitement" +
                    $" de requête à {DateTime.Now}");
                await context.Response.WriteAsync("Middleware1");

                await next();

                int x = 0;
                Debug.WriteLine(x);
            });
        }

        static public void UseMiddleware2(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                Debug.WriteLine($"Middleware2: Traitement" +
                    $" de requête à {DateTime.Now}");
                await context.Response.WriteAsync("Middleware2");

                await next();

                int x = 0;
                Debug.WriteLine(x);
            });
        }
        static public void UseMiddleware3(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                Debug.WriteLine($"Middleware3: Traitement" +
                    $" de requête à {DateTime.Now}");
                await context.Response.WriteAsync("Middleware3");

                await next();

                int x = 0;
                Debug.WriteLine(x);
            });
        }

        static public void MapMiddleware1(this WebApplication app)
        => app.Map("/middleware1", 
            application => application.
            Response.WriteAsync("Appel au middleware1"));

        static public void MapMiddleware2(this WebApplication app)
       => app.Map("/middleware1",
           application => application.
           Response.WriteAsync("Appel au middleware2"));

        static public void MapMiddleware3(this WebApplication app)
       => app.Map("/middleware1",
           application => application.
           Response.WriteAsync("Appel au middleware3"));

        static public void UseMonMiddleware(this WebApplication app)
            => app.UseMiddleware<MonMiddleware>();


    }
}
