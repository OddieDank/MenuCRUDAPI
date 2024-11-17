using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebMenuAPI.Models
{
    public class DetalleOrden
    {
        [Key]
        public int OrdenDtId { get; set; }

        [ForeignKey("Orden")]
        public int OrdenId { get; set; }
        public required Orden Orden { get; set; }

        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public required Producto Producto { get; set; }

        public required decimal Cantidad { get; set; }

        public required DateTime UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
