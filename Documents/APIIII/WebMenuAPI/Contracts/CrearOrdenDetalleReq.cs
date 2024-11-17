using System.ComponentModel.DataAnnotations;

public class CrearOrdenDetalleReq{
    [Required]
    public int OrdenId { get; set; }

    [Required]
    public int ProductoId { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Cantidad { get; set; }

    [Required]
    public DateTime UpdatedOn { get; set; }
}