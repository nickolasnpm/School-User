using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var ValidIssuer = builder.Configuration["Jwt:Issuer"];
var ValidAudience = builder.Configuration["Jwt:Audience"];
var IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!));

builder.Services.AddControllerClass();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerAndSecurity();
builder.Services.AuthenticationAndAuthorization(ValidIssuer!, ValidAudience!, IssuerSigningKey);
builder.Services.AddPersistence(connectionString!);
builder.Services.AddExternalLibraries(connectionString!);
builder.Services.AddServicesLifetime();
builder.Services.ConfigureApiBehaviors();
builder.Services.AddResilenceStrategy();
builder.Services.AddLogging(); 
// test 

var app = builder.Build();

app.ConfigurePersistenceScoped();

app.UseSwagger();
app.UseSwaggerUI();

app.ConfigureMiddleware();

app.ConfigureCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.ConfigureHangfireSettings();

await app.RunAsync();