using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlushTheToiletClient.Models
{
    public class DistanceDTO
    {
        [JsonProperty]
        public double Distance { get; set; }
    }
}
