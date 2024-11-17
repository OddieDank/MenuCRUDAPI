using System;
using System.ComponentModel.DataAnnotations;

namespace WebMenuAPI.Models
{
    public class StatusOrden
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nombre { get; set; }

        public required DateTime UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
