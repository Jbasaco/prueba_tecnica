using PruebaAPI.Entities.Mysql;
using PruebaAPI.Helpers;
using PruebaAPI.Repository.Core;
using System.Linq.Expressions;

namespace PruebaAPI.Repository.MySQL
{
    public class RestauranteRepositoryImpl : CoreRepositoryImpl<Restaurante>, IRestauranteRepository
    {


        public RestauranteRepositoryImpl(DataContext dataContext)
            : base(dataContext)
        {

        }
    }
}
