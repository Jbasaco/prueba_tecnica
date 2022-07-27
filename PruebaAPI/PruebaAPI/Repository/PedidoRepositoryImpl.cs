using PruebaAPI.Entities;
using PruebaAPI.Helpers;
using PruebaAPI.Repository.Core;

namespace PruebaAPI.Repository
{
    public class PedidoRepositoryImpl : CoreRepositoryImpl<Pedido>, IPedidoRepository
    {
        public PedidoRepositoryImpl(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
