using Microsoft.AspNetCore.Mvc;
using PruebaAPI.Entities;
using PruebaAPI.Models;
using PruebaAPI.Service;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace PruebaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PruebaTecnicaController : ControllerBase
    {

        private readonly ILogger<PruebaTecnicaController> _logger;
        private readonly IRestauranteService _restauranteService;
        private readonly IPedidoService _pedidoService;


        public PruebaTecnicaController(ILogger<PruebaTecnicaController> logger, IRestauranteService restauranteService, IPedidoService pedidoService)
        {
            _logger = logger;
            _restauranteService = restauranteService;
            _pedidoService = pedidoService;
        }

        [HttpGet(Name = "GetClimaActual")]

        public async Task<WeatherTask> GetClimaActual(string ciudad)
        {
            WeatherTask respuesta = new WeatherTask();
            using (var weatherClient = new HttpClient())
            {

                weatherClient.BaseAddress = new Uri("http://api.weatherstack.com/");
                weatherClient.DefaultRequestHeaders.Accept.Clear();
                weatherClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await weatherClient.GetAsync("current?access_key=0edab2e2f502285e3efc30831433bfbc&query=" + ciudad);


                string jsonString = await response.Content.ReadAsStringAsync();

                JsonNode forecastNode = JsonNode.Parse(jsonString)!;

                respuesta.temperatura = int.Parse(forecastNode!["current"]["temperature"]!.ToString());
                respuesta.humedad = int.Parse(forecastNode!["current"]["humidity"]!.ToString());

            }


            return respuesta;
        }


        [HttpGet(Name ="GetRestaurante")]
        public ActionResult<Restaurante> GetRestaurante(string nombre)
        {
            Restaurante restaurante = _restauranteService.get(nombre);

            return restaurante;
        }

        [HttpPost(Name = "GuardarPedido")]
        public async Task<Pedido> GuardarPedido(PedidoModel pedido)
        {
            Pedido p = new Pedido();

            p.cabecera = pedido.cabecera;
            p.detalle = pedido.detalle;

            Restaurante res = _restauranteService.get(pedido.restaurante);
            p.RestauranteID = res.Id;

            WeatherTask clima = await GetClimaActual(res.ubicacionRestaurante);
            p.fecha = DateTime.Now;
            p.temperatura = clima.temperatura;
            p.humedad = clima.humedad;

            Pedido created = _pedidoService.guardar(p);

            return created;
        }
    }
}