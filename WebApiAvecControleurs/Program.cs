#define injection
using Microsoft.AspNetCore.Mvc.Formatters;
using WebApiAvecControleurs.Models;

namespace WebApiAvecControleurs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(
                options =>
                {
                    options.OutputFormatters.Insert(0,new XmlSerializerOutputFormatter());
                    /*Impl�menter CustomOutPutFormatter pour avoir une sortie
                     personnalis�e du WebApi*/
                    options.OutputFormatters.Insert(1, new CustomOutPutFormatter());
                }
                );
            //Injection de service Swagger
            builder.Services.AddSwaggerGen();

#if injection           
            //Ajouter l'acc�s aux donn�es sous forme de service
            builder.Services.AddScoped(typeof(ICarContext), typeof(CarContext));
#endif
            


            var app = builder.Build();



            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });


            app.MapControllers();

            app.Run();
        }
    }
}