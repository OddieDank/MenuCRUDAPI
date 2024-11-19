using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebMenuAPI.Contracts{
public class CrearUsuarioReq
{
    [Required]
    [StringLength(100)]
    public required string Nombre { get; set; }

    [Required]
    [StringLength(20)]
    public required  string Telefono { get; set; }

    [Required]
    [EmailAddress]
    public required  string Email { get; set; }

    [Required]
    public required bool Admin { get; set; }

    [Required]
    [StringLength(255)]
    public required string Password { get; set; }

    public DateTime UpdatedOn { get; set; } = DateTime.Now;

    public DateTime? DeletedOn { get; set; }

}

public class CrearProductoReq
{
    [Required]
    [ForeignKey("Categoria")]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(100)]
    public required string Nombre { get; set; }
    [Required]
    [StringLength(256)]
    public required string Descripcion { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
    public decimal Precio { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0.")]
    public decimal Cantidad { get; set; }

    public string? Imagen { get; set; }
    public DateTime UpdatedOn { get; set; } = DateTime.Now;


    [Required]
    public bool Activo { get; set; }
}

public class CrearPagoReq
{
    [Required]
    public int OrdenId { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero.")]
    public required decimal Monto { get; set; }

    [Required]
    [StringLength(50)]
    public required string MetodoPago { get; set; }

    public DateTime UpdatedOn { get; set; } = DateTime.Now;
}

public class CrearOrdenReq
{
    [Required]
    public int UsuarioId { get; set; }

    [Required]
    public int StatusId { get; set; }

    public DateTime UpdatedOn { get; set; } = DateTime.Now;

    [Required]
    public bool ParaLlevar { get; set; }

    [Required]
    public int LocacionId { get; set; }
}

public class CrearOrdenDetalleReq{
    [Required]
    public int OrdenId { get; set; }

    [Required]
    public int ProductoId { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    public decimal Cantidad { get; set; }

    public DateTime UpdatedOn { get; set; } = DateTime.Now;

}


public class CrearLocacionReq
{
    [Required]
    [StringLength(50)]
    public required string Mesa { get; set; }

    public DateTime UpdatedOn { get; set; } = DateTime.Now;
}

public class CrearComentarioReq{
    [Required]
    public int UsuarioId { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
    public int Calificacion { get; set; }

    [Required]
    [StringLength(500, ErrorMessage = "El comentario no puede superar los 500 caracteres.")]
    public required string ComentarioText { get; set; }

    public DateTime UpdatedOn { get; set; } = DateTime.Now;


    public DateTime? DeletedOn { get; set; }
}

public class ActualizarUsuarioReq
{
    [StringLength(100)]
    public required string Nombre { get; set; }

    [StringLength(20)]
    public required string Telefono { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    public required bool? Admin { get; set; }

    [StringLength(255)]
    public required string Password { get; set; }

    public DateTime UpdatedOn { get; set; } = DateTime.Now;

    public DateTime? DeletedOn { get; set; }
}
public class ActualizarProductoReq
{
    [StringLength(100)]
    public string? Nombre { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
    public decimal? Precio { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor que 0.")]
    public decimal? Cantidad { get; set; }

    public DateTime UpdatedOn { get; set; } = DateTime.Now;

    public bool? Activo { get; set; }
    public string? Imagen { get; set; }
    public DateTime? DeletedOn { get; set; }
}

public class ActualizarOrdenReq
{
    public int? StatusId { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal? TotalPrice { get; set; }

    public DateTime UpdatedOn { get; set; } = DateTime.Now;

    public DateTime? DeletedOn { get; set; }

    public TimeSpan? TiempoEnCompletar { get; set; }

    public bool? ParaLlevar { get; set; }

    public int? LocacionId { get; set; }
}

public class ActualizarOrdenDetalleReq
{
    [ForeignKey("Producto")]
    public int? ProductoId { get; set; }

    [Required]
    [Range(0.1, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
    public decimal? Cantidad { get; set; }

    public DateTime UpdatedOn { get; set; } = DateTime.Now;

    public DateTime? DeletedOn { get; set; }
}

public class ActualizarLocacionReq
{
    [StringLength(50)]
    public required string Mesa { get; set; }

    public DateTime UpdatedOn { get; set; } = DateTime.Now;

    public DateTime? DeletedOn { get; set; }
}

public class ActualizarComentarioReq
{
    [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
    public int Calificacion { get; set; }

    [StringLength(500, ErrorMessage = "El comentario no puede superar los 500 caracteres.")]
    public required string ComentarioText { get; set; }

    public DateTime UpdatedOn { get; set; } = DateTime.Now;

    public DateTime? DeletedOn { get; set; }
}
}