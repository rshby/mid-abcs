using inq_cif.Repositories;
using inq_cif.Resolver;
using inq_cif.Services;

var builder = WebApplication.CreateBuilder(args);

// register DbContext

// register Repository Layer
builder.Services.AddTransient<ABCS_M_CFMAST_Repository>();

// register Service Layer
builder.Services.AddTransient<InterfaceInqCifService, InqCifService>();

// register GraphQL Server
builder.Services.AddGraphQLServer().AddQueryType<InqCifQueryType>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// add GraphQL Endpoint
app.MapGraphQL();

app.Run();
