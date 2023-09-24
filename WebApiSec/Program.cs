using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApiSec.Model;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var connstring = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WebMvcoreSec2DbContext>(options => options.UseSqlServer(connstring));

/************************** CONFIGURATION  JWT ************************************/

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JWTKey:ValidIssuer"],
        ValidAudience = builder.Configuration["JWTKey:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["JWTKey:Secret"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

/**************************** CONFIGURATION  JWT ****************************************/




// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

/*************************** CONFIGURATION  JWT ***********************************/

app.UseAuthentication();
app.UseAuthorization();
/************************** CONFIGURATION  JWT ************************************/

app.MapControllers();

app.Run();
