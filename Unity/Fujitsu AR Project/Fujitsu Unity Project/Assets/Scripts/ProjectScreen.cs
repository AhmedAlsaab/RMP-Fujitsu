using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;
using System.Text;
using SimpleJSON;
using Vuforia;

public class ProjectScreen : MonoBehaviour, ITrackableEventHandler {

    private string baseURL = "https://live.runmyprocess.com/";
    public GameObject MarketingCanvas;
    private TrackableBehaviour trackableBehaviour;
    private bool ShowGUIButton = false;
    private Rect ButtonRect = new Rect(50, 50, 120, 60);
    private int projectLimit = 1;
    public GameObject projectPrefab;
    public GameObject projectParent;
    private int processAligner = 0;
	
	// Use this for initialization
	void Start () {
        trackableBehaviour = GetComponent<TrackableBehaviour>();
        if (trackableBehaviour)
        {
            trackableBehaviour.RegisterTrackableEventHandler(this);
        }

		StartCoroutine(GetText());
	}

 IEnumerator GetText() {
		var username = "cristiano.bellucci.fujitsu+cardiffadmin@gmail.com";
		var password = "Millennium";


		var credentials = Convert.ToBase64String (Encoding.ASCII.GetBytes (username + ":" + password)); // FROM TEAM 7
		WWWForm form = new WWWForm();  // FROM TEAM 7
		var headers = form.headers;  // FROM TEAM 7
		headers ["Authorization"] = "Basic " + credentials;  // FROM TEAM 7
		headers ["Accept"] = "application/json";

		WWW www = new WWW("https://live.runmyprocess.com/config/112761542179152739/user/993079/project/?filter=NAME&operator=CONTAINS&value=CWL$_$market&method=GET&P_rand=17306", null, headers);

		yield return www;


		// Preparation for process generation.
		var jsonObject =  JSON.Parse(www.text);
		var arrayOfProcesses = jsonObject["feed"]["entry"].AsArray;

		int i = 0;

        // Getting the process report.
        foreach (var arrayItem in arrayOfProcesses.Values)
        {
            if (i < projectLimit)
            {

                GameObject createdProject = createProject(arrayItem["title"].Value);

                // Adding in title for process.
                createdProject.GetComponentsInChildren<Text>()[0].text = arrayItem["title"].Value;

            }
        }
	}
	

    void Update()
    {
                        // MarketingCanvas.SetActive(false);

    }

    GameObject createProject(string projectTitle)
    {
        GameObject individualProject = Instantiate(projectPrefab);
        individualProject.transform.SetParent(projectParent.transform, false);

        individualProject.transform.Translate(0, processAligner, 0);

        processAligner -= 75;

        individualProject.GetComponentsInChildren<Text>()[0].text = projectTitle;

        return individualProject;
    }

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED  ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            ShowGUIButton = true;
            // MarketingCanvas.SetActive(true);
            // Debug.Log("Canvas set to active");
        }
        else if(previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NOT_FOUND 
             || previousStatus == TrackableBehaviour.Status.EXTENDED_TRACKED && newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("canvas set to true");
            ShowGUIButton = true;
            // MarketingCanvas.SetActive(true);

        }
        else 
        {
            ShowGUIButton = false;
            // MarketingCanvas.SetActive(false);
            Debug.Log("canvas set to false");

        }
       
    }

    void OnGUI()
    {
        if (ShowGUIButton)
        {
        
            GUI.Button(ButtonRect, "Hello");
            
        }
    }
	
}
