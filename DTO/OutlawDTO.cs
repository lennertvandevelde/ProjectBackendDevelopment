using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectBackendDevelopment.Models;

namespace ProjectBackendDevelopment.DTO
{
    public class OutlawDTO
    {
        public Guid OutlawId { get; set; }
        [Required]
        public string OutlawUri { get; set; }
        [Required]
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string DeathDate { get; set; }
        public Guid DeathCauseId { get; set; }
        public List<Guid> Gangs { get; set; }

        public string Description { get; set; }

    }
}
