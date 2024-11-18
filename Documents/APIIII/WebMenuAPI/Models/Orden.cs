using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMenuAPI.Models
{
    public class Orden
    {
        [Key]
        public int OrdenId { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public required Usuario Usuario { get; set; }

        [ForeignKey("StatusOrden")]
        public int StatusId { get; set; }
        public required StatusOrden StatusOrden { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]

        public required decimal TotalPrice { get; set; }

        public required DateTime UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public TimeSpan? TiempoEnCompletar { get; set; }
        public required bool ParaLlevar { get; set; }

        [ForeignKey("Locacion")]
        public int LocacionId { get; set; }
        public required Locacion Locacion { get; set; }
    }
}
