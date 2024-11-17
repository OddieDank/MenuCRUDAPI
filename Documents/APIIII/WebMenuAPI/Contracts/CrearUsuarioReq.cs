using System.ComponentModel.DataAnnotations;

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

    [Required]
    public required  DateTime UpdatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    [Required]
    [StringLength(100)]
    public required  string Perfil { get; set; }
}
