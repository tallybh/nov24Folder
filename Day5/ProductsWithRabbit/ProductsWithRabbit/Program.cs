using ProductsWithRabbit.Contracts;
using ProductsWithRabbit.Models;
using ProductsWithRabbit.Rabbit;
using ProductsWithRabbit.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRabbitMQProducer, RabbitMQProducer>();
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
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

app.Run();
