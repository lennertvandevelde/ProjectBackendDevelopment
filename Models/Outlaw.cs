using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectBackendDevelopment.Models
{
    public class Outlaw
    {
        public Guid OutlawId { get; set; }
        [Required]
        public Uri OutlawUri { get; set; }
        [Required]
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string DeathDate { get; set; }
        public Guid DeathCauseId { get; set; }
        [Required]
        public string Description { get; set; }
        public string Thumbnail { get; set; }
    }
}
