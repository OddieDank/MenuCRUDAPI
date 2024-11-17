using System.ComponentModel.DataAnnotations;

public class ActualizarOrdenReq
{
    public int? StatusId { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal? TotalPrice { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public TimeSpan? TiempoEnCompletar { get; set; }

    public bool? ParaLlevar { get; set; }

    public int? LocacionId { get; set; }
}
