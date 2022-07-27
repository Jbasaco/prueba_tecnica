using PruebaAPI.Entities.Mysql;

namespace PruebaAPI.Service
{
    public interface IPedidoService
    {
        public Pedido get(int id);
        public Pedido get(string cabecera);

        public Pedido guardar(Pedido pedido);
    }
}
