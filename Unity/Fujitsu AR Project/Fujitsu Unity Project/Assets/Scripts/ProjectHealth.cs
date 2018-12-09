using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;
using System.Text;
using SimpleJSON;

public class ProjectHealth : MonoBehaviour {

   
    private string baseURL = "https://live.runmyprocess.com/";
    private int StatusLimit = 100;
    public GameObject StatusContainerPrefab;
    public GameObject StatusContainerParent;
    private int StatusAligner = 0;
    int Count301 = 0;
    int Count201 = 0;
    int Count102 = 0;
    int TotalStatusCount = 0;
    int FailingAndPending = 0;
    [SerializeField] private float currentAmount;
    [SerializeField] private float speed;
    public GameObject RadialBarPrefab;
    public GameObject RadialBarParent;
    public bool ThisHasBeenCalled = false;
    public int RadialBarAligner = 0;
    public GameObject[] RadialBar;
    private List<int> RadialBarDaTa = new List<int>();
    int track = 0;

   

	// Use this for initialization
	void Start () {
        
		 StartCoroutine(RunThisApi("https://live.runmyprocess.com/live/112761542179152739/request?operator=EE%20EE%20IS&column=name%20status%20events%20published%20updated&value=215357%20ACCEPTANCE%20NULL&filter=PROJECT%20MODE%20PARENT&nb=20&first=0&method=GET&P_rand=77540"));
         StartCoroutine(RunThisApi("https://live.runmyprocess.com/live/112761542179152739/requestreport/CWL%20Market%20Campaign%20Report.csv?operator=EE%20EE%20IS&column=name%20status%20events%20published%20updated&value=215356%20ACCEPTANCE%20NULL&filter=PROJECT%20MODE%20PARENT&nb=20&first=0&method=GET&P_rand=34765"));
	}
	
	// Update is called once per frame
	void Update () {

        
        

        try
        {

             // 0 Index = MarketingFairAPI || 1 Index = MarketingCampaignAPI
           
            
            RadialBar = GameObject.FindGameObjectsWithTag("RadialBar");

            if (RadialBarDaTa.Count > 1 && RadialBar.Length > 1)
            {



                for (var i = 0; i < RadialBar.Length; i++)
                {
                    if (currentAmount < RadialBarDaTa[i])
                    {
                        currentAmount += speed * Time.deltaTime;
                        RadialBar[i].GetComponentsInChildren<Text>()[0].text = ((int)currentAmount).ToString() + "%";
                        RadialBar[i].GetComponentsInChildren<Text>()[1].gameObject.SetActive(true);
                        RadialBar[i].GetComponentsInChildren<Image>()[1].fillAmount = currentAmount / 100;
                        if (currentAmount > RadialBarDaTa[i])
                        {
                             Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                            Debug.Log("Finished Radial Progress");
                            //RadialBar[i].GetComponentsInChildren<Image>()[1].fillAmount = currentAmount / 100;
                            continue;
                        }
                    }
                    else
                    {
                        RadialBar[i].GetComponentsInChildren<Text>()[1].text = "Failure Rate";
                    }
                   

                }
            }
  
        }

        catch (IndexOutOfRangeException e)
        {
            //print error if u want
        }
        
       
       
      
	}


    void ProgressIndicator()
    {
      
    }

   

    

   
    GameObject createStatus(float c102, float c201, float c301, float total )
    {
        GameObject StatusCodeBox = Instantiate(StatusContainerPrefab);
        StatusCodeBox.transform.SetParent(StatusContainerParent.transform, false);
        StatusCodeBox.transform.Translate(0, StatusAligner, 0);
        StatusCodeBox.GetComponentsInChildren<Text>()[0].text = ((c201 / total) * 100).ToString().Split('.')[0] + "%";
        StatusCodeBox.GetComponentsInChildren<Text>()[1].text = ((c102 / total) * 100).ToString().Split('.')[0] + "%";
        StatusCodeBox.GetComponentsInChildren<Text>()[2].text = ((c301 / total) * 100).ToString().Split('.')[0] + "%";
        StatusAligner -= 75;
        return StatusCodeBox;
    }

    GameObject SpawningRadialBar(float xCount102, float xCount201, float xCount301, 
        int xTotalStatusCount, int xFailingAndPending)
    {

        GameObject RadialBar = Instantiate(RadialBarPrefab);
        RadialBar.transform.SetParent(RadialBarParent.transform, false);
        RadialBar.transform.Translate(0, RadialBarAligner, 0);
        RadialBarAligner = -200;
        return RadialBar;
    }

    IEnumerator RunThisApi(string url)
    {
        var username = "cristiano.bellucci.fujitsu+cardiffadmin@gmail.com";
		var password = "Millennium";


		var credentials = Convert.ToBase64String (Encoding.ASCII.GetBytes (username + ":" + password)); // FROM TEAM 7
		WWWForm form = new WWWForm();  // FROM TEAM 7
		var headers = form.headers;  // FROM TEAM 7
		headers ["Authorization"] = "Basic " + credentials;  // FROM TEAM 7
		headers ["Accept"] = "application/json";

		WWW www = new WWW(url, null, headers);

		yield return www;


		// Preparation for process generation.
		var jsonObject =  JSON.Parse(www.text);
		var arrayOfProcessStatus = jsonObject["feed"]["entry"].AsArray;

		int i = 0;
         Count301 = 0;
         Count201 = 0;
         Count102 = 0;
         TotalStatusCount = 0;
         // yield return new WaitForSeconds(1);
        
        // Getting the process report.
        foreach (var arrayItem in arrayOfProcessStatus.Values)
        {
          

            if(arrayItem["category"][0]["label"].AsInt == 201)
            {
                Count201++;
                
             }
            else if(arrayItem["category"][0]["label"].AsInt == 301)
            {
                Count301++;
                

               
            }
            else if(arrayItem["category"][0]["label"].AsInt == 102)
            {
                Count102++;
               
                
                

               
                
            }
           
            TotalStatusCount++;

		}
        ProgressBar.Status102 = Count102;
        ProgressBar.Status201 = Count201;
        ProgressBar.Status301 = Count301;
        ProgressBar.TotalStatusCounter = TotalStatusCount;
        FailingAndPending = (Count301 + Count102);
        StatusCounter statusCounter = new StatusCounter(Count102, Count201, Count301, TotalStatusCount, FailingAndPending);
        RadialBarDaTa.Add(statusCounter.FailureRate);
        ApiFilter.counts.Add(statusCounter);

        
        ProgressBar.FailingAndPendingStatus = FailingAndPending;
        createStatus(Count102, Count201, Count301, TotalStatusCount);
        SpawningRadialBar(Count102, Count201, Count301, TotalStatusCount, FailingAndPending);
        
          
        

     

        
    }

        
    
}
