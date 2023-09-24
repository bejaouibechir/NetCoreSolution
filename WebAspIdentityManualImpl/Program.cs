using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAspIdentityManualImpl.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

var configuration = builder.Configuration;

var connstring = configuration.GetConnectionString("defaultconnection");

//Le service d'acc�s � la base qui stocke les informations de s�curit�
//La chaine est d�finie dans le fichier de configuration appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>
    (
    opt=>opt.UseSqlServer(connstring)
);

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

//Le service d'identit�
//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    //.AddEntityFrameworkStores<ApplicationDbContext>()
    //.AddDefaultTokenProviders();

//Ajouter quelques options relatives aux polotique d'authentification 
//et d'autorisation

builder.Services.Configure<IdentityOptions>(
    opt =>
    {
        opt.Password.RequireUppercase = true;
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
        opt.Lockout.MaxFailedAccessAttempts = 3;
        opt.User.RequireUniqueEmail = true;
    }
    );


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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
