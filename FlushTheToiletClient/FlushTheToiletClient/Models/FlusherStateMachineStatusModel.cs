using System;
using System.Collections.Generic;
using System.Text;

namespace FlushTheToiletClient.Models
{
    public class FlusherStateMachineStatusModel
    {
        public bool IsInAutomaticMode { get; set; }
        public double Distance { get; set; }
        public string CurrentState { get; set; }
    }
}
