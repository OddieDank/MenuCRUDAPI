using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMenuAPI.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public required Categoria Categoria { get; set; }

        [Required]
        [StringLength(100)]
        public required string Nombre { get; set; }

        public required decimal Precio { get; set; }
        public required decimal Cantidad { get; set; }

        public required DateTime UpdatedOn { get; set; }
        public required bool Activo { get; set; }	
        public DateTime? DeletedOn { get; set; }
    }
}