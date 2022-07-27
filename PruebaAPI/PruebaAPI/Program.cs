using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PruebaAPI.Entities.Mongo;
using PruebaAPI.Helpers;
using PruebaAPI.Repository.Core;
using PruebaAPI.Repository.Mongo;
using PruebaAPI.Repository.MySQL;
using PruebaAPI.Service;

var builder = WebApplication.CreateBuilder(args);


#region configuración Mongo


builder.Services.Configure<PedidoDBConf>(
builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.AddSingleton<IPedidoDBConf>(sp =>
sp.GetRequiredService<IOptions<PedidoDBConf>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
new MongoClient(builder.Configuration.GetValue<string>("MongoDBSettings:ConnectionString")));
builder.Services.AddScoped<IPedidoMongoService, PedidoMongoServiceImpl>();


#endregion



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configuración MYSQL
builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ApiMysqlBD");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IRestauranteRepository, RestauranteRepositoryImpl>();
builder.Services.AddScoped<IRestauranteService, RestauranteServiceImpl>();

builder.Services.AddScoped<IPedidoRepository, PedidoRepositoryImpl>();
builder.Services.AddScoped<IPedidoService, PedidoServiceImpl>();
#endregion


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
