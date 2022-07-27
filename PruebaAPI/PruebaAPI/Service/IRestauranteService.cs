using PruebaAPI.Entities.Mysql;

namespace PruebaAPI.Service
{
    public interface IRestauranteService
    {
        public Restaurante get(int id);
        public Restaurante get(string nombre);
    }
}
