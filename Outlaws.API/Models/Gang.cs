using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Outlaws.API.Models
{
    public class Gang
    {
        public Guid GangId { get; set; }
        public string GangName { get; set; }
        public string GangUri { get; set; }
        [JsonIgnore]
        public List<GangOutlaw> GangOutlaws { get; set; }
    }
}
