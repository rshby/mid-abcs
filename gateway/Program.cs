using gateway;

var builder = WebApplication.CreateBuilder(args);

// register node service
builder.Services.AddHttpClient(ListSchema.SaInquiry, x => x.BaseAddress = new Uri("http://localhost:1000/graphql"));

// register GraphQL Server
builder.Services.AddGraphQLServer().AddRemoteSchema(ListSchema.SaInquiry);
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

// add graphQL
app.MapGraphQL();

app.Run();
