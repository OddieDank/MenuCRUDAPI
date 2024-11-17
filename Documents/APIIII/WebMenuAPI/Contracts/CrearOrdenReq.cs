using System.ComponentModel.DataAnnotations;

public class CrearOrdenReq
{
    [Required]
    public int UsuarioId { get; set; }

    [Required]
    public int StatusId { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal TotalPrice { get; set; }

    [Required]
    public DateTime UpdatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public TimeSpan? TiempoEnCompletar { get; set; }

    [Required]
    public bool ParaLlevar { get; set; }

    [Required]
    public int LocacionId { get; set; }
}
