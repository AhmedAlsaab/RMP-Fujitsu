using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;
using System.Text;
using SimpleJSON;

public class RadialBar : MonoBehaviour {

    public static int Status102;
    public static int Status201;
    public static int Status301;
    public static int TotalStatusCounter;
    public static int FailingAndPendingStatus;
    public Transform LoadingBar;
    public Transform TextIndicator;
    public Transform TextLoading;
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;



	// Use this for initializaation
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       int pendinghealth = FailingAndPendingStatus * 100 / TotalStatusCounter;
        if(currentAmount < pendinghealth)
        {
           currentAmount += speed * Time.deltaTime;
           TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
           TextLoading.gameObject.SetActive(true);
             
       }
        else
       {
            TextLoading.GetComponent<Text>().text = "Failure Rate";
           
        }

         LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
		
	}
}
