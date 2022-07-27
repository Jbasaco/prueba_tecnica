using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PruebaAPI.Entities.Mysql;

namespace PruebaAPI.Entities.Mongo
{
    public class MongoPedido
    {
        [BsonId]
        public int ID { get; set; }

        [BsonElement("cabecera")]
        public string cabecera { get; set; }
        [BsonElement("detalle")]

        public string detalle { get; set; }
        [BsonElement("temperatura")]

        public int temperatura { get; set; }
        [BsonElement("humedad")]

        public int humedad { get; set; }
        [BsonElement("nombreRestaurante")]

        public string Restaurante { get; set; }
        [BsonElement("fecha")]

        public DateTime? fecha { get; set; }

        public MongoPedido(Pedido ped, string nombreRestaurante)
        {
            this.ID = ped.ID;
            this.cabecera = ped.cabecera;
            this.detalle = ped.detalle;
            this.fecha = ped.fecha;
            this.humedad = ped.humedad;
            this.temperatura = ped.temperatura;
            this.Restaurante = nombreRestaurante;
        }

    }
}
