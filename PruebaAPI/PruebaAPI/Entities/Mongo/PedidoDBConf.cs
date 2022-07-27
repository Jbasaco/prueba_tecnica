namespace PruebaAPI.Entities.Mongo
{
    public class PedidoDBConf:IPedidoDBConf
    {
        public string PedidosCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
