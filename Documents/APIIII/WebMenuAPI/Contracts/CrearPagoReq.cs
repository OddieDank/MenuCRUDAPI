using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CreatePagoRequest
{
    [Required]
    public int OrdenId { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero.")]
    public required decimal Monto { get; set; }

    [Required]
    [StringLength(50)]
    public required string MetodoPago { get; set; }

    [Required]
    public required DateTime UpdatedOn { get; set; }
}
