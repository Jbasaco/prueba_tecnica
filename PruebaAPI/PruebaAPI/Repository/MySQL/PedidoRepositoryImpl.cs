using PruebaAPI.Entities.Mysql;
using PruebaAPI.Helpers;
using PruebaAPI.Repository.Core;

namespace PruebaAPI.Repository.MySQL
{
    public class PedidoRepositoryImpl : CoreRepositoryImpl<Pedido>, IPedidoRepository
    {
        public PedidoRepositoryImpl(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
