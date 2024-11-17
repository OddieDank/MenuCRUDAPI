using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UpdateProductoRequest
{
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
    public decimal? Precio { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0.")]
    public decimal? Cantidad { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? Activo { get; set; }

    public DateTime? DeletedOn { get; set; }
}
