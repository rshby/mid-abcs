using inq_accont.Data;
using inq_accont.Repositories;
using inq_accont.Resolver;
using inq_accont.Services.Casa;
using inq_accont.Services.Deposit;
using inq_accont.Services.GL;
using inq_accont.Services.Loan;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// register DbContext
string? middlewareConnectionString = builder.Configuration.GetConnectionString("MiddlewareDB");
builder.Services.AddDbContext<MiddlewareDBContext>(x => x.UseSqlServer(middlewareConnectionString), ServiceLifetime.Transient);

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<InqAccountContext>(x => x.UseSqlServer(connectionString), ServiceLifetime.Transient);

// register Repository Layer
builder.Services.AddTransient<BRINJOURNALSEQ_Repository>();
builder.Services.AddTransient<ABCS_M_DDMEMO_Repository>();
builder.Services.AddTransient<ABCS_M_DDMAST_Repository>();
builder.Services.AddTransient<ABCS_M_CDMEMO_Repository>();
builder.Services.AddTransient<ABCS_M_CDMAST_Repository>();
builder.Services.AddTransient<ABCS_M_GLMEMO_Repository>();
builder.Services.AddTransient<ABCS_M_GLMAST_Repository>();
builder.Services.AddTransient<ABCS_M_LNMAST_Repository>();
builder.Services.AddTransient<ABCS_M_LNMEMO_Repository>();
builder.Services.AddTransient<ABCS_P_DDPAR2_Repository>();
builder.Services.AddTransient<ABCS_T_TLLOG_Repository>();

// register Service Layer
builder.Services.AddTransient<InterfaceInqCasaService, InqCasaService>();
builder.Services.AddTransient<InterfaceInqDepositService, InqDepositService>();
builder.Services.AddTransient<InterfaceInqGlService, InqGlService>();
builder.Services.AddTransient<InterfaceInqLoanService, InqLoanService>();

// register GraphQL Server
builder.Services.AddGraphQLServer().AddQueryType<InqAccountQueryType>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
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