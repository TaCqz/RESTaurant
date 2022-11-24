using RESTaurant;
using RESTaurant.Entities;
using RESTaurant.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Init starting values
MainContext.InitStartingValues();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Swagger dient zum Testen der Requests
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Standard-Setup für ASP.NET Programme (von der Vorlage erstellt)
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
