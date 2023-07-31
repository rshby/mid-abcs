using gateway;

var builder = WebApplication.CreateBuilder(args);

// register node service
builder.Services.AddHttpClient(ListSchema.CifInquiry, c => c.BaseAddress = new Uri("http://localhost:2000/graphql"));
//builder.Services.AddHttpClient(ListSchema.Inquiry, x => x.BaseAddress = new Uri("http://localhost:2001/graphql"));
//builder.Services.AddHttpClient(ListSchema.SaInquiry, x => x.BaseAddress = new Uri("http://localhost:2002/graphql"));
builder.Services.AddHttpClient(ListSchema.AccountNumberInquiry, x => x.BaseAddress = new Uri("http://localhost:2003/graphql"));

// register GraphQL Server
builder.Services.AddGraphQLServer()
   //.AddRemoteSchema(ListSchema.SaInquiry)
   //.AddRemoteSchema(ListSchema.Inquiry)
   .AddRemoteSchema(ListSchema.CifInquiry)
   .AddRemoteSchema(ListSchema.AccountNumberInquiry);

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
