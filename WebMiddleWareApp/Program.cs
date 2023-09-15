using System.Diagnostics;

namespace WebMiddleWareApp
{
    public class Program
    {


        static public void methode(WebApplication application)
        {
            ;
        }

        public static void Main(string[] args)

        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            

           


            //#region Création de middleware directement avec la méthode Use
            ////Middeware 1
            //app.Use(async (context, next) =>
            //{
            //    Debug.WriteLine($"Middleware1: Traitement" +
            //        $" de requête à {DateTime.Now}");
            //    await context.Response.WriteAsync("Middleware1");

            //    await next();

            //    int x = 0;
            //    Debug.WriteLine(x);
            //});

            ////Middeware 2
            //app.Use(async (context, next) =>
            //{
            //    Debug.WriteLine($"Middleware2: Traitement" +
            //        $" de requête à {DateTime.Now}");
            //    await context.Response.WriteAsync("Middleware2");

            //    await next();

            //    int x = 0;
            //    Debug.WriteLine(x);
            //});

            ////Middeware 3
            //app.Use(async (context, next) =>
            //{
            //    Debug.WriteLine($"Middleware3: Traitement" +
            //        $" de requête à {DateTime.Now}");
            //    await context.Response.WriteAsync("Middleware3");

            //    await next();

            //    int x = 0;
            //    Debug.WriteLine(x);
            //});

            //#endregion

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.UseMiddleware<MonMiddleware>();

            app.UseMonMiddleware();

            
            //Forme basique d'appel de middlewar via la méthode Map
            app.Map("/middleware1", application => application.Response.WriteAsync("Appel au middleware1"));

            app.Map("/middleware2", application => application.Response.WriteAsync("Appel au middleware2"));

            app.Map("/middleware3", application => application.Response.WriteAsync("Appel au middleware3"));

            //context.User.IsInRole("Admin") permet de tester si l'utilisateur
            //est en rôle admin

            //                     Condition
           //                           |
           //                           v
            
            app.MapWhen(context=>!context.User.IsInRole("Admin"), 
                
           //              Le middleware à déclencher
                
           //                          |
           //                          v
                application => application.Run(
                context => context.Response.WriteAsync("Appel du middleware" +
                "reussi")
                )) ;

           

            //Appel du middleware avce des méthodes extensions sur la base de Map


            app.MapMiddleware1();
            app.MapMiddleware2();
            app.MapMiddleware3();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            /*app.UseMiddleware1();

            app.UseMiddleware2();

            app.UseMiddleware3();*/

            app.Run();

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Middleware lancé depuis" +
            //        "la méthode Run");
            //});

            


           
        }

        
    }
}