using ContosoPizza.Data;
using ContosoPizza.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registers PizzaContext with ASP.NET Core's dependency injection system.
//Defines a SQLite connection string that points to a local file, ContosoPizza.db.
builder.Services.AddSqlite<PizzaContext>("Data Source=ContosoPizza.db");

//Adds a scoped service of the type specified in PizzaService to the specified IServiceCollection.
builder.Services.AddScoped<PizzaService>();

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
//calls the extension method whenever the app runs.
app.CreateDbIfNotExists();
app.Run();
