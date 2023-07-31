using cif_inquiry.Data;
using cif_inquiry.Repositories;
using cif_inquiry.Resolver;
using cif_inquiry.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// register DbContext
string? connectionString = builder.Configuration.GetConnectionString("MySqlConnect");
builder.Services.AddDbContext<CifInquiryContext>(db => db.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)), ServiceLifetime.Transient);

// register Repository Layer
builder.Services.AddTransient<ABCS_M_CFMAST_Repository>();

// regiser Services Layer
builder.Services.AddTransient<ICifInquiryService, CifInquiryService>();

// register GraphQL Server
builder.Services.AddGraphQLServer().AddQueryType<CifInquiryQueryType>();

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

// add GraphQL endpoint
app.MapGraphQL();

app.Run();
