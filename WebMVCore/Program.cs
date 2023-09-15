using Microsoft.Extensions.FileProviders;
using Unity;
using WebMVCore;
using WebMVCore.Filters;
using WebMVCore.Services;

var logsrvdescriptor = new ServiceDescriptor(typeof(IService),
    typeof(LogService), ServiceLifetime.Transient);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(typeof(IHttpContextAccessor),
    typeof(HttpContextAccessor));


builder.Services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(30));




//builder.Services.AddAuthentication("CookieScheme")
//    .AddCookie("CookieScheme", options =>
//    {
//        options.LoginPath = "/";
//        options.AccessDeniedPath = "/Error";
//    });

builder.Services.AddScoped<LogActionFilter>();
builder.Services.AddScoped<ExceptionFilter>();
var configuration = builder.Configuration;

builder.Services.AddLogging(
    b => b.AddDebug()
);



// options=>options.Filters.Add<AuthorizationFilter>()

// Add services to the container.
builder.Services.AddControllersWithViews(
    );

builder.Services.AddSingleton(typeof(IUnityContainer), typeof(UnityContainer));

//Une première forme d'injection de service
//builder.Services.Add(logsrvdescriptor);
//Une deuxième forme d'injection de service
//builder.Services.AddTransient(typeof(IService), typeof(LogService));
//Une trosième forme d'injection de service
builder.Services.AddLogService();

builder.Services.AddSingleton(typeof(ISingletonService),
    typeof(SingletonService)) ;

builder.Services.AddScoped(typeof(IScopedService),
    typeof(ScopedService));

builder.Services.AddTransient(typeof(ITransientService),
    typeof(TransientService));


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else if(app.Environment.IsDevelopment())
{
    ;
}
else if(app.Environment.IsStaging())
{
    ;
}

app.UseHttpsRedirection();

//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider("C:\\temp\\contents"),
//    RequestPath = new PathString("/contents")
//}); 
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

//app.MapControllerRoute(
//    name: "second",
//    pattern: "{controller=Home}/{action=Index}/{id:int}");

//La requête sous forme 123 en utilisant l'argument constraint
//app.MapControllerRoute(
//    name: "Product1",
//    pattern: "products/{code}",
//    defaults: new { controller = "Home", action = "Product" },
//    constraints: new { code = @"\d{3}" }
//);


//La requête sous forme 123 en définissant la contrainte au sein du
//template
//app.MapControllerRoute(
//    name: "Product2",
//    pattern: "products/{code:int:lenght(3)}",
//    defaults: new { controller = "Home", action = "Product" }
    
//);

//Imposer une contrainte fortement typée sous forme de classe
//app.MapControllerRoute(
//    name: "Product2",
//    pattern: "products/{code}",
//    defaults: new { controller = "Home", action = "Product" },
//    constraints: new RoutingConstraint()

//);

app.Run();
