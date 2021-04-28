using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Outlaws.API.Models;

namespace Outlaws.API.DTO
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
