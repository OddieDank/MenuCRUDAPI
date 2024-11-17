using System.ComponentModel.DataAnnotations;
public class CreateLocacionRequest
{
    [Required]
    [StringLength(50)]
    public required string Mesa { get; set; }

    public DateTime UpdatedOn { get; set; }
}