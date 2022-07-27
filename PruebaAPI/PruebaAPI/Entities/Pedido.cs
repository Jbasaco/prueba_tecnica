using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaAPI.Entities
{
    public class Pedido
    {
        public int ID { get; set; }
        public string cabecera { get; set; }
        public string detalle { get; set; }

        public int temperatura { get; set; }
        public int humedad { get; set; }

        public int RestauranteID { get; set; }

        public DateTime? fecha { get; set; }
        [ForeignKey("RestauranteID")]
        public Restaurante restaurante { get; set; }
    }
}
