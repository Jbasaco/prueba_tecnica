using System.ComponentModel.DataAnnotations;

namespace PruebaAPI.Entities
{
    public class Restaurante
    {
        [Key]
        public int Id { get; set; }
        public string nombreRestaurante { get; set; }
        public string ubicacionRestaurante { get; set; }

    }
}
