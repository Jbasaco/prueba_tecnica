using PruebaAPI.Entities;
using PruebaAPI.Helpers;
using PruebaAPI.Repository.Core;
using System.Linq.Expressions;

namespace PruebaAPI.Repository
{
    public class RestauranteRepositoryImpl : CoreRepositoryImpl<Restaurante>, IRestauranteRepository
    {


        public RestauranteRepositoryImpl(DataContext dataContext)
            : base(dataContext)
        {

        }
    }
}
