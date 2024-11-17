using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMenuAPI.Models
{
    public class Comentario
    {
        [Key]
        public int ComentarioId { get; set; }

        [ForeignKey("Usuario")] 
        public int UsuarioId { get; set; } 

        public required int Calificacion { get; set; }

        [StringLength(500)]
        public required string ComentarioText { get; set; }

        public required DateTime UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
