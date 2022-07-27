using PruebaAPI.Entities.Mongo;

namespace PruebaAPI.Repository.Mongo
{
    public interface IPedidoMongoService
    {
        List<MongoPedido> Get();
        MongoPedido Get(string id);
        MongoPedido Crear(MongoPedido pedido);
    }
}
