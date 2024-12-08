
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using MiniApi;

List<Product> products = new List<Product>();
products.Add(new Product { Id = 1, Name = "Bread", Price = 10 });

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/products", () =>
{
    return products;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/products/{id}", (int id) =>
{
    return products.Where(p => p.Id == id);
}).WithName("GetProductById")
.WithOpenApi();


app.MapPost("/Products", ([FromBody] Product p) =>
    {
        p.Id = products.Max(p => p.Id) + 1;
        products.Add(p);
    }).WithOpenApi();

app.MapPut("/Products", ([FromBody] Product p) =>
    {
        var product = products.Where(p1 => p1.Id == p.Id).FirstOrDefault();
        products.Remove(product);
        products.Add(p);
    }).WithOpenApi();

app.MapDelete("/Products", async (int id) =>
{
    var product = products.Where(p1 => p1.Id == id).FirstOrDefault();
    products.Remove(product);
}).WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
