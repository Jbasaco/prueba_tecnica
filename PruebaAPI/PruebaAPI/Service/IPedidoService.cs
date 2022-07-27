using PruebaAPI.Entities;

namespace PruebaAPI.Service
{
    public interface IPedidoService
    {
        public Pedido get(int id);
        public Pedido get(string cabecera);

        public Pedido guardar(Pedido pedido);
    }
}
