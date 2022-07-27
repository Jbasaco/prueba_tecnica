using MongoDB.Driver;
using PruebaAPI.Entities.Mongo;

namespace PruebaAPI.Repository.Mongo
{
    public class PedidoMongoServiceImpl : IPedidoMongoService
    {

        private readonly IMongoCollection<MongoPedido> _pedidos;

        public PedidoMongoServiceImpl(IPedidoDBConf settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _pedidos = database.GetCollection<MongoPedido>(settings.PedidosCollectionName);
        }

        public MongoPedido Crear(MongoPedido pedido)
        {
            _pedidos.InsertOne(pedido);
            return pedido;
        }

        public List<MongoPedido> Get()
        {
            return _pedidos.Find(pedido => true).ToList();
        }

        public MongoPedido Get(string id)
        {
            return _pedidos.Find(ped => ped.ID.Equals(id)).FirstOrDefault();
        }
    }
}
