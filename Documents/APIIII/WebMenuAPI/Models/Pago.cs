using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMenuAPI.Models
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }

        [ForeignKey("Orden")]
        public int OrdenId { get; set; }
        public required Orden Orden { get; set; }

        public required decimal Monto { get; set; }

        [StringLength(50)]
        public required string MetodoPago { get; set; }

        public DateTime? DeletedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
