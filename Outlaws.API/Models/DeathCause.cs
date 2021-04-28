using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Outlaws.API.Models
{
    public class DeathCause
    {
        public Guid DeathCauseId { get; set; }
        [Required]
        public string Description { get; set; }
        public string DeathUri { get; set; }
        [JsonIgnore]
        public List<Outlaw> Outlaws { get; set; }
    }
}
