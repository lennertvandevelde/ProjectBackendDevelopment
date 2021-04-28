using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Outlaws.API.Models
{
    public class Outlaw
    {
        public Guid OutlawId { get; set; }
        [Required]
        public string OutlawUri { get; set; }
        [Required]
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string DeathDate { get; set; }
        [JsonIgnore]
        public Guid DeathCauseId { get; set; }
        public DeathCause DeathCause { get; set; }
        public List<GangOutlaw> GangOutlaws { get; set; }
        public string Description { get; set; }
        

    }
}
