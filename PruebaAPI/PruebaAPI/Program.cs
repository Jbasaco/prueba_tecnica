using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PruebaAPI.Helpers;
using PruebaAPI.Repository;
using PruebaAPI.Repository.Core;
using PruebaAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ApiMysqlBD");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IRestauranteRepository, RestauranteRepositoryImpl>();
builder.Services.AddScoped<IRestauranteService, RestauranteServiceImpl>();

builder.Services.AddScoped<IPedidoRepository, PedidoRepositoryImpl>();
builder.Services.AddScoped<IPedidoService, PedidoServiceImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();
app.UseAuthorization();

app.MapControllers();

app.Run();
