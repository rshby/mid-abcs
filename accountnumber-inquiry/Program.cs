using accountnumber_inquiry.Data;
using accountnumber_inquiry.Repositories;
using accountnumber_inquiry.Resolver;
using accountnumber_inquiry.Services;
using Inquiry.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// register DbContext
string? connectionString = builder.Configuration.GetConnectionString("MySqlConnect");
builder.Services.AddDbContext<AccountNumberInquiryContext>(db => db.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)), ServiceLifetime.Transient);

// register Repository Layer
builder.Services.AddTransient<ABCS_M_CDMAST_Repo>();
builder.Services.AddTransient<ABCS_M_CDMEMO_Repo>();
builder.Services.AddTransient<ABCS_M_DDMAST_Repo>();
builder.Services.AddTransient<ABCS_M_DDMEMO_Repo>();
builder.Services.AddTransient<ABCS_M_GLMAST_Repo>();
builder.Services.AddTransient<ABCS_M_GLMEMO_Repo>();
builder.Services.AddTransient<ABCS_M_LNMAST_Repo>();
builder.Services.AddTransient<ABCS_M_LNMEMO_Repo>();

// register Service Layer
builder.Services.AddTransient<IAccountNumberInquiryService, AccountNumberInquiryService>();

// register GraphQL Server
builder.Services.AddGraphQLServer().AddQueryType<AccountNumberInquiryQueryType>();

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
