using PruebaAPI.Entities;

namespace PruebaAPI.Service
{
    public interface IRestauranteService
    {
        public Restaurante get(int id);
        public Restaurante get(string nombre);
    }
}
