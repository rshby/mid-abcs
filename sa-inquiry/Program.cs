using Microsoft.EntityFrameworkCore;
using sa_inquiry.Data;
using sa_inquiry.Repositories;
using sa_inquiry.Resolver;
using sa_inquiry.Services;

var builder = WebApplication.CreateBuilder(args);

// register database context
string? connectionString = builder.Configuration.GetConnectionString("MySqlConnect");
builder.Services.AddDbContext<SaInquiryContext>(option => option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)), ServiceLifetime.Transient);

// register Repository Layer
builder.Services.AddTransient<ABCS_M_DDMAST_Repo>();

// register Service Layer
builder.Services.AddTransient<ISaInquiryService, InquiryService>();

// register GraphQL Server
builder.Services.AddGraphQLServer().AddQueryType<SaInquiryQueryType>();

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

// add GraphQL
app.MapGraphQL();

app.Run();
