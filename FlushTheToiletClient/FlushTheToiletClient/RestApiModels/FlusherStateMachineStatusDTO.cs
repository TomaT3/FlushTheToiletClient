using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlushTheToiletClient.RestApiModels
{
    public class FlusherStateMachineStatusDTO
    {
        [JsonProperty]
        public bool IsInAutomaticMode { get; set; }

        [JsonProperty]
        public double Distance { get; set; }

        [JsonProperty]
        public string CurrentState { get; set; }
    }
}
