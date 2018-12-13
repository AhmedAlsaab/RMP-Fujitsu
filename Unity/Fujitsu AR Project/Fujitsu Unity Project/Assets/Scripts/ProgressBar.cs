using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;
using System.Text;
using SimpleJSON;

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

    // Update is called once per frame
    void Update() {
        try {


            int PendingStatusForAllApiLinks = ApiFilter.counts[0].Status102 + ApiFilter.counts[1].Status102;
            int PendingStatusCounterTotal = ApiFilter.counts[0].TotalStatusCounter + ApiFilter.counts[1].TotalStatusCounter;
            int PendingTotal = PendingStatusForAllApiLinks * 100 / PendingStatusCounterTotal;



            if (PendingCurrentAmount < PendingTotal)
            {
                PendingCurrentAmount += PendingSpeed * Time.deltaTime;
                PendingTextIndicator.GetComponent<Text>().text = ((int)PendingCurrentAmount).ToString() + "%";
            }
        }
        catch (Exception e)
        {
            //print error if u want
        }

        PendingLoadingBar.GetComponent<Image>().fillAmount = PendingCurrentAmount / 100;
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
            //print error if u want
        }

        SuccessLoadingBar.GetComponent<Image>().fillAmount = SuccessCurrentAmount / 100;


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
            //print error if u want
        }
        FailingLoadingBar.GetComponent<Image>().fillAmount = FailingCurrentAmount / 100;
       
	}


   

}
