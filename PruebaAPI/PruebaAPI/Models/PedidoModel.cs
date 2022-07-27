using System.ComponentModel.DataAnnotations;

namespace PruebaAPI.Models
{
    public class PedidoModel
    {
        [Required]
        public string cabecera { get; set; }
        [Required]

        public string detalle { get; set; }
        [Required]

        public string restaurante { get; set; }
    }
}
