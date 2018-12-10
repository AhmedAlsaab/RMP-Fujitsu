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

public class ProjectScreen : MonoBehaviour {

    private string baseURL = "https://live.runmyprocess.com/";
    private TrackableBehaviour trackableBehaviour;
    private bool ShowGUIButton = false;
    private bool ProjectButtonsCreated = false;
    public GameObject[] ProjectButtonArray;
    private Rect ButtonRect = new Rect(50, 50, 120, 60);
    private int projectLimit = 5;
    public GameObject projectPrefab;
    public GameObject projectParent;
    private int projectAligner = 0;
    private Dictionary<GameObject, bool> check = new Dictionary<GameObject, bool>();
    private bool BtnAssignerCalled = false;
    
    
	
	// Use this for initialization
	void Start () {
        

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
			i++;

		}

        
	}

    // https://answers.unity.com/questions/52683/how-i-can-call-a-function-once-on-the-update-funct.html
    // Calling an update function once
    void Update()
    {

        try
        {
            ProjectButtonArray = GameObject.FindGameObjectsWithTag("ProjectButton");

            if (ProjectButtonArray.Length >= 1) //size u want
            {
                
                if (BtnAssignerCalled == false)
                {
                    
                    ProjectBtnAssigner();
                }
            }
        }
        catch (IndexOutOfRangeException e)
        {
            //print error if u want
        }

    }
   void ProjectBtnAssigner()
    {
        foreach (GameObject gameObject in ProjectButtonArray)
        {
            GetComponentsInChildren<Button>()[0].onClick.AddListener(OpenMarketingCampaignProcessList);
            GetComponentsInChildren<Button>()[1].onClick.AddListener(OpenMarketingFairProcessList);
        }
        BtnAssignerCalled = true;
    }

    

   

    // Find Intro screen and Activiate
     
        // Find Intro screen and Deactivate

    void IntroScreenFinderAndDeactivator()
    {
        GameObject IntroScreen = GameObject.FindGameObjectWithTag("IntroScreen");
        IntroScreen.transform.SetAsFirstSibling();

    }

        // Find Marketing Campaign Process list and Activiate

    void MarketingCampaignFinderAndActivator()
    {
        GameObject CampaignProcessList = GameObject.FindGameObjectWithTag("CampaignList");
        CampaignProcessList.transform.SetAsLastSibling();
    }
            // Find Marketing Fair Process list and Activiate

    void MarketingFairFinderAndActivator()
    {
        GameObject FairProcessList = GameObject.FindGameObjectWithTag("FairList");
        FairProcessList.transform.SetAsLastSibling();
    }

    // Call Marketing Campaign process finder
    // Call Intro Screen Deactivator 
    void OpenMarketingCampaignProcessList()
    {
        IntroScreenFinderAndDeactivator();
        MarketingCampaignFinderAndActivator();
    }

    // Call Marketing Fair process finder
    // Call Intro Screen Deactivator 

    void OpenMarketingFairProcessList()
    {
        IntroScreenFinderAndDeactivator();
        MarketingFairFinderAndActivator();
    }

    

   

    
   

    GameObject createProject(string projectTitle)
    {
        GameObject individualProject = Instantiate(projectPrefab);
        individualProject.transform.SetParent(projectParent.transform, false);

        individualProject.transform.Translate(projectAligner, 0,  0 );

        individualProject.GetComponentsInChildren<Text>()[0].text = projectTitle;

        projectAligner = 300;

      
        return individualProject;
    }

    

    
	
}
