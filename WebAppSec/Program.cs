using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Inside ConfigureServices method
     builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Validate the issuer of the token
            ValidateAudience = true, // Validate the audience of the token
            ValidateLifetime = true, // Validate the token expiry
            ValidateIssuerSigningKey = true, // Validate the signing key

            ValidIssuer = "https://localhost:7235", // Replace with your issuer URL
            ValidAudience = "https://localhost:7235", // Replace with your audience URL
            IssuerSigningKey 
            = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("test123++")) // Replace with your secret key
        };
    });

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
