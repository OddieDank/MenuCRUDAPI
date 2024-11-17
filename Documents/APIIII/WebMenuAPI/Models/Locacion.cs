using System;
using System.ComponentModel.DataAnnotations;

namespace WebMenuAPI.Models
{
    public class Locacion
    {
        [Key]
        public int LocacionId { get; set; }

        [StringLength(50)]
        public required string Mesa { get; set; }

        public required DateTime UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
