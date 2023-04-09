
//using EasyFixADLRepositoryLib.Models;

using BuildingADLRepositoryLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using RepositoryPattern.Core;
using RepositoryPattern.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("EasyFixAppDbConnection");
builder.Services.AddDbContext<TechnicalSupportContext>(options => options.UseSqlServer(connString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        b => b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

});
 
//builder.Services.AddControllers().AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.PropertyNamingPolicy = null;
//});
builder.Services.AddControllersWithViews().
        AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });
//builder.Services.AddMvc().Configure<MvcOptions>(options =>
//{
//    var jsonOutputFormatter = new JsonOutputFormatter();
//    jsonOutputFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
//    jsonOutputFormatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Ignore;

//    options.OutputFormatters.Insert(0, jsonOutputFormatter);
//});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles(); //upload files
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Photo")),
    RequestPath = new PathString("/Photo")
});

app.UseCors(builder =>
{
    builder
    .WithOrigins(new string[] { "http://localhost:4200", "http://building.buschcranes.com/" })
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials();
});

//app.UseCors(
//               //options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowCredentials()
//               options => options.WithOrigins("https://easyfix-oman.com/", "https://cp.easyfix-oman.com/").AllowAnyMethod().AllowCredentials()
//           );
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});


app.MapControllerRoute(
    name: "api",
    pattern: "api/{*endpoint}",
    defaults: new { controller = "Containers", action = "ApiCreate" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Containers}/{action=Index}/{id?}");
//app.MapRazorPages();
app.UseRouting(); 
app.UseAuthentication();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapControllers();
app.Run();

