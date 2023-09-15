using WebApiSimplifiée.Models;




namespace WebApiSimplifiée
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddScoped(typeof(ICarContext),typeof(CarContext));

            //builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.UseCors("AllowAll");

            //Middleware pour recevoir l'ensemble des voitures
            //      uri template            le middleware
            //             |                         | 
            //             v                         v   
            app.MapGet("api/cars",(CarContext db)=> db.GetCars().ToList());


            //Middleware pour recevoir une voiture sur la base de son id
            app.MapGet("api/cars/{id}",(int id,CarContext db)=> db.GetCar(id));

            
            //Middleware pour ajouter une voiture à la liste des voitures
            app.MapPost("/cars", (Car car, CarContext db) =>
            db.AddCar(car));

            //Middleware pour mettre à jour une voiture de la liste
            app.MapPut("/cars/{id}", (int id, Car newcar, CarContext db) =>
               db.UpdateCar(id,newcar)
            );

            //Middleware pour supprimer une voiture de la liste
            app.MapDelete("/cars/{id}", (int id, CarContext db) =>
             db.DeleteCar(id)
            );

 
            app.Run();
        }
    }
}