using System.ComponentModel.DataAnnotations;

public class UpdateUsuarioReq
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

    public required DateTime? UpdatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }
}
