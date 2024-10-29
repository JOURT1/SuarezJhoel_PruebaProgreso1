using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace SuarezJhoel_PruebaProgreso1.Models
{
    public class JSuarez
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [AllowNull]
        [EmailAddress]
        public string Correo { get; set; }

        [Range(0, 100)]
        public decimal Edad { get; set; }

        public Boolean Donante_de_organos { get; set; }

        public DateOnly FechaNaciemiento { get; set; }

    }
}
