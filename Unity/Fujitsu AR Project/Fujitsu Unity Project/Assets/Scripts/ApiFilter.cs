using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiFilter {

    public static List<StatusCounter> counts = new List<StatusCounter>();
  
}

public class StatusCounter
    {
        public int Status102 { get; set; }
        public int Status201 { get; set; }
        public int Status301 { get; set; }
        public int TotalStatusCounter { get; set; }
        public int FailingAndPendingCounter { get; set; }
    public int FailureRate { get; set; }

    public StatusCounter(int Status102, int Status201, int Status301, 
            int TotalStatusCounter, int FailingAndPendingCounter)
        {
            this.Status102 = Status102;
            this.Status201 = Status201;
            this.Status301 = Status301;
            this.TotalStatusCounter = TotalStatusCounter;
            this.FailingAndPendingCounter = FailingAndPendingCounter;
            this.FailureRate = FailingAndPendingCounter * 100 / TotalStatusCounter;
        }
    }
