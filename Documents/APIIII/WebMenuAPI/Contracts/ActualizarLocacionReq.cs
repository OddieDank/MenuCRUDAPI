using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class UpdateLocacionRequest
{
    [StringLength(50)]
    public required string Mesa { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }
}
