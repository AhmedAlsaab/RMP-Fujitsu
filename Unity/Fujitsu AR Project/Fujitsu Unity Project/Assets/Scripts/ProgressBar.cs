using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;
using System.Text;
using SimpleJSON;

// C1443907
// Progress Bar Charts that represent the overall state of the department
public class ProgressBar : MonoBehaviour {
    public static int Status102;
    public static int Status201;
    public static int Status301;
    public static int TotalStatusCounter;
    public static int FailingAndPendingStatus;
    [SerializeField] private float PendingCurrentAmount;
    [SerializeField] private float PendingSpeed;
    public Transform PendingTextIndicator;
    public Transform PendingLoadingBar;
    [SerializeField] private float SuccessCurrentAmount;
    [SerializeField] private float SuccessSpeed;
    public Transform SuccessTextIndicator;
    public Transform SuccessLoadingBar;
    [SerializeField] private float FailingCurrentAmount;
    [SerializeField] private float FailingSpeed;
    public Transform FailingTextIndicator;
    public Transform FailingLoadingBar;
   
   

	// Use this for initialization
	void Start () {
       
	}

    // Update method is a Unity reserved method that performs the functionality placed within once per frame (fast, continous until requirement has been fulfilled)
    // The segment below needs to be in the update method
    void Update() {
        // Try block as Index will be out of range untill data is passed in by API
        // Fetching from both API Lists specified by Index
        // Adding the total amount of status 102 (pending) from link 0 and link 1 together
        // Adding the total amount of statuses to find out what % status 102 contributes to out of a 100%
        try {
            int PendingStatusForAllApiLinks = ApiFilter.counts[0].Status102 + ApiFilter.counts[1].Status102;
            int PendingStatusCounterTotal = ApiFilter.counts[0].TotalStatusCounter + ApiFilter.counts[1].TotalStatusCounter;
            int PendingTotal = PendingStatusForAllApiLinks * 100 / PendingStatusCounterTotal;
            // PendingCurrentAmount is 0 by default, PendingTotal will be greater and run the If block until it is not greater
            if (PendingCurrentAmount < PendingTotal)
            {
                // Defining the speed of how fast the empty bar should fill up
                // Printing the % that is also updated continously as the progress bar fills up
                PendingCurrentAmount += PendingSpeed * Time.deltaTime;
                PendingTextIndicator.GetComponent<Text>().text = ((int)PendingCurrentAmount).ToString() + "%";
            }
        }
        catch (Exception e)
        {
            //Index Out of Range: Pending Bar Chart
        }
        // The fill amount for the empty bar is 0 by default, the fill amount should eventually (when done) be the total amount of pending status'
        // Fillamount variables can only be decimals 0 to 1 and therefore needs to be devided by 100
        // Example: 58% of all status' found are pending (102) - Bar chart should fill up with a yellow color up to 58% of the bar
        PendingLoadingBar.GetComponent<Image>().fillAmount = PendingCurrentAmount / 100;


        // Successfull Bar Chart
        try {
            int SuccessStatusForAllApiLinks = ApiFilter.counts[0].Status201 + ApiFilter.counts[1].Status201;
            int SuccessStatusCounterTotal = ApiFilter.counts[0].TotalStatusCounter + ApiFilter.counts[1].TotalStatusCounter;
            int SuccessTotal = SuccessStatusForAllApiLinks * 100 / SuccessStatusCounterTotal;

            if (SuccessCurrentAmount < SuccessTotal)
            {
                SuccessCurrentAmount += SuccessSpeed * Time.deltaTime;
                SuccessTextIndicator.GetComponent<Text>().text = ((int)SuccessCurrentAmount).ToString() + "%";
            }
        }
        catch (Exception e)
        {
            //Index Out of Range: Success Bar Chart
        }

        SuccessLoadingBar.GetComponent<Image>().fillAmount = SuccessCurrentAmount / 100;


        // Failing Bar Chart
        try { 
        int FailingStatusForAllApiLinks = ApiFilter.counts[0].Status301 + ApiFilter.counts[1].Status301;
        int FailingStatusCounterTotal = ApiFilter.counts[0].TotalStatusCounter + ApiFilter.counts[1].TotalStatusCounter;
        int FailingTotal = FailingStatusForAllApiLinks * 100 / FailingStatusCounterTotal;

        if (FailingCurrentAmount < FailingTotal)
        {
            FailingCurrentAmount += FailingSpeed * Time.deltaTime;
            FailingTextIndicator.GetComponent<Text>().text = ((int)FailingCurrentAmount).ToString() + "%";
        }
    }
        catch (Exception e)
        {
            //Index Out of Range: Failing Bar Chart
        }
        FailingLoadingBar.GetComponent<Image>().fillAmount = FailingCurrentAmount / 100;
       
	}


   

}
