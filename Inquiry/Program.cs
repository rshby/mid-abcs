using Inquiry.Data;
using Inquiry.Repositories;
using Inquiry.Resolver;
using Inquiry.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add database contect
string? connectionString = builder.Configuration.GetConnectionString("MySqlConnect");
builder.Services.AddDbContext<InquiryContext>(db => db.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)), ServiceLifetime.Transient);

// register Repository Layer
builder.Services.AddTransient<ABCS_M_CFMAST_Repo>();
builder.Services.AddTransient<ABCS_M_DDMAST_Repo>();
builder.Services.AddTransient<ABCS_M_DDMEMO_Repo>();

// register Service Layer
builder.Services.AddTransient<InterfaceInquiryService, InquiryService>();

// add GraphQLServer
builder.Services.AddGraphQLServer().AddQueryType<InquiryQueryType>();

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

// add graphql
app.MapGraphQL();

app.Run();
