using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string? Correo { get; set; }

        public double DineroDisponibloe { get; set; }

        public Boolean Donante_de_organos { get; set; }

        public DateTime FechaNaciemiento { get; set; }

        [ForeignKey("Celular")]
        public int IdCelular { get; set; }
        public Celular? Celular { get; set; }
    }
}
