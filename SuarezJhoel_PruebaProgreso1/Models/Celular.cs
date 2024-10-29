using System.ComponentModel.DataAnnotations;

namespace SuarezJhoel_PruebaProgreso1.Models
{
    public class Celular
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Modelo { get; set; }
        public DateTime año { get; set; }

        public double Precio { get; set; }
    }
}
