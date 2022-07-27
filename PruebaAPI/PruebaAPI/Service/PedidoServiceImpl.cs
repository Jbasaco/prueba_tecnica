using PruebaAPI.Entities.Mysql;
using PruebaAPI.Repository.MySQL;

namespace PruebaAPI.Service
{
    public class PedidoServiceImpl : IPedidoService
    {
        protected readonly IPedidoRepository _repos;

        public PedidoServiceImpl(IPedidoRepository repos)
        {
            _repos = repos;
        }
        public Pedido get(int id)
        {
            var res = _repos.GetOne(r => r.ID == id).FirstOrDefault();

            if (res == null)
                throw new Exception();
            return res;
        }

        public Pedido get(string cabecera)
        {
            var res = _repos.GetOne(r => r.cabecera == cabecera).FirstOrDefault();

            if (res == null)
                throw new Exception();
            return res;
        }

        public Pedido guardar(Pedido pedido)
        {
            return _repos.Create(pedido);
        }
    }
}
