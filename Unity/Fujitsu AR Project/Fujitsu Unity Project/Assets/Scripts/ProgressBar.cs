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
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;
   // public Transform TextIndicator;
   // public Transform TextLoading;
   // public Transform LoadingBar;
    public GameObject RadialBarPrefab;
    public GameObject RadialBarParent;
    public bool ThisHasBeenCalled = false;
    public int RadialBarAligner = 0;

	// Use this for initialization
	void Start () {
        SpawningRadialBar();
	}
	
	// Update is called once per frame
	void Update () {
       
       
       //int pendinghealth = FailingAndPendingStatus * 100 / TotalStatusCounter;
       // if(currentAmount < pendinghealth)
       // {
       //    currentAmount += speed * Time.deltaTime;
       //    TextIndicator.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
       //    TextLoading.gameObject.SetActive(true);
             
       //}
       // else
       //{
       //     TextLoading.GetComponent<Text>().text = "Failure Rate";
           
       // }
        Debug.Log("CHCKIIIIIIIIIIIIIIIIIIIIIIIIII " + ApiFilter.counts[0].Status102);
       // LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;

         try
        {
            

            
                  if (ThisHasBeenCalled == false)
                {
                    SpawningRadialBar();
                }
            
        }
        catch (IndexOutOfRangeException e)
        {
            //print error if u want
        }
        SpawningRadialBar();
       
	}


    GameObject SpawningRadialBar()
    {
        
        GameObject RadialBar = Instantiate(RadialBarPrefab);
        RadialBar.transform.SetParent(RadialBarParent.transform, false);
        RadialBar.transform.Translate(0, RadialBarAligner, 0);
     //   RadialBar.GetComponentsInChildren<Text>()[0].text = ApiFilter.counts[0].Status102.ToString();
     //   RadialBar.GetComponentsInChildren<Text>()[1].text = ApiFilter.counts[1].FailingAndPendingCounter.ToString();
        RadialBarAligner = -75;
        

        int pendinghealth = FailingAndPendingStatus * 100 / TotalStatusCounter;
        if(currentAmount < pendinghealth)
        {
            currentAmount += speed * Time.deltaTime;
            RadialBar.GetComponentsInChildren<Text>()[0].text = ((int)currentAmount).ToString() + "%";
            RadialBar.GetComponentsInChildren<Text>()[1].gameObject.SetActive(true);

            
        }
        else
        {
            RadialBar.GetComponentsInChildren<Text>()[1].text = "Failure Rate";
        }
       
    
         RadialBar.GetComponentsInChildren<Image>()[1].fillAmount = currentAmount / 100;

        ThisHasBeenCalled = true;
        return RadialBar;


    }

}
