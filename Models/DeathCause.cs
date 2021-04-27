using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectBackendDevelopment.Models
{
    public class DeathCause
    {
        public Guid DeathCauseId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
