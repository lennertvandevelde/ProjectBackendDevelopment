using System;
using System.Text.Json.Serialization;

namespace Outlaws.API.Models
{
    public class GangOutlaw
    {
        [JsonIgnore]
        public Guid GangId { get; set; }
        public Gang Gang { get; set; }
        [JsonIgnore]
        public Guid OutlawId { get; set; }
        [JsonIgnore]
        public Outlaw Outlaw { get; set;}

    }
}
