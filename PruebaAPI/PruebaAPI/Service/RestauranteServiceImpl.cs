using PruebaAPI.Entities.Mysql;
using PruebaAPI.Repository.MySQL;

namespace PruebaAPI.Service
{
    public class RestauranteServiceImpl : IRestauranteService
    {

        protected readonly IRestauranteRepository _repos;

        public RestauranteServiceImpl(IRestauranteRepository repos)
        {
            _repos = repos;
        }

        public Restaurante get(int id)
        {
            var res = _repos.GetOne(r => r.Id == id).FirstOrDefault();

            if (res == null)
                throw new Exception();
            return res;
        }

        public Restaurante get(string nombre)
        {
            var res = _repos.GetOne(r => r.nombreRestaurante.Equals(nombre)).FirstOrDefault();

            if (res == null)
                throw new Exception();
            return res;
        }
    }
}
