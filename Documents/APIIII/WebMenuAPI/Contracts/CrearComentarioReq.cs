using System.ComponentModel.DataAnnotations;

public class CrearComentarioReq{
    [Required]
    public int UsuarioId { get; set; }

    [Required]
    [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5.")]
    public int Calificacion { get; set; }

    [Required]
    [StringLength(500, ErrorMessage = "El comentario no puede superar los 500 caracteres.")]
    public required string ComentarioText { get; set; }

    [Required]
    public DateTime UpdatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }
}