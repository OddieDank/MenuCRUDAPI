using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ActualizarOrdenDetalleReq
{
    [Required]
    [ForeignKey("Producto")]
    public int ProductoId { get; set; }

    [Required]
    [Range(0.1, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
    public decimal Cantidad { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }
}

