using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class CreateProductoRequest
{
    [Required]
    [ForeignKey("Categoria")]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(100)]
    public required string Nombre { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
    public decimal Precio { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0.")]
    public decimal Cantidad { get; set; }

    public DateTime UpdatedOn { get; set; }

    [Required]
    public bool Activo { get; set; }
}
