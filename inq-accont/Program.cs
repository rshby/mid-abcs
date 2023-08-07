using inq_accont.Data;
using inq_accont.Repositories;
using inq_accont.Resolver;
using inq_accont.Services.Casa;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// register DbContext
string? connectionString = builder.Configuration.GetConnectionString("");
builder.Services.AddDbContext<InqAccountContext>(x => x.UseSqlServer(connectionString), ServiceLifetime.Transient);

// register Repository Layer
builder.Services.AddTransient<ABCS_M_DDMEMO_Repository>();
builder.Services.AddTransient<ABCS_M_DDMAST_Repository>();

// register Service Layer
builder.Services.AddTransient<InterfaceInqCasaService, InqCasaService>();

// register GraphQL Server
builder.Services.AddGraphQLServer().AddQueryType<InqAccountQueryType>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
   var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
       .ToArray();
   return forecast;
})
.WithName("GetWeatherForecast");

// add GraphQL Endpoint
app.MapGraphQL();

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
   public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}