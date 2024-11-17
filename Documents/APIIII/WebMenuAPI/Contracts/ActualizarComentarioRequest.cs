using System.ComponentModel.DataAnnotations;

public class ActualizarComentarioRequest
{
    [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
    public int? Calificacion { get; set; }

    [StringLength(500, ErrorMessage = "El comentario no puede superar los 500 caracteres.")]
    public string? ComentarioText { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }
}
