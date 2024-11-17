using System;
using System.ComponentModel.DataAnnotations;

namespace WebMenuAPI.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [StringLength(100)]
        public required string Nombre { get; set; }

        public required DateTime UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
