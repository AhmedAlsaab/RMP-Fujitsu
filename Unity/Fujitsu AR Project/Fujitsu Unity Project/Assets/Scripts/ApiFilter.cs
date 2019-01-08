using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// C1443907
// Static class developed to allow us to access data from various scripts

public class ApiFilter {

    // Initialiaze new static list: counts
    // Each list corresponds to a new API, accessed by index
    // Variables within list stay the same, but also accessed by index: Link[5] ProjectHealth || Link[3] ProjectHealth
    public static List<StatusCounter> counts = new List<StatusCounter>();
  
}

public class StatusCounter
    {

    //Getting and Setting the variables fed into this static class
        public int Status102 { get; set; }
        public int Status201 { get; set; }
        public int Status301 { get; set; }
        public int TotalStatusCounter { get; set; }
        public int FailingAndPendingCounter { get; set; }
        public int FailureRate { get; set; }
    // Constructor 
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
