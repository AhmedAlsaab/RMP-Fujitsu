using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;
using System.Text;
using SimpleJSON;

// All script is based on my (c1645238) experimental work on another repository.
// https://gitlab.cs.cf.ac.uk/c1645238/personal-ar-experiment/blob/master/Assets/Scripts/Spawner.cs
// REF CHANGING TEXT LOGIC: https://docs.unity3d.com/ScriptReference/UI.Text-text.html

// Based On Tutorial on how to spawn object using c# https://www.youtube.com/watch?v=XO-E6QaTniQ
// Published on May 25, 2017 By Renaissance Coders Accessed on 20.11.2018.
// Video title: Unity C# Creating and Deleting Objects

// Inspired By Unity Documentations - how to change position using Transform.translate.
// https://docs.unity3d.com/ScriptReference/Transform.Translate.html
// Accessed on 20.11.2018.
public class ProcessDetailInserter : MonoBehaviour {
	public Text processMenuTitle;
	public Text processBoxTitle;

	public GameObject stepParentObject;
	public GameObject stepPrefab;
	public Transform stepSpawnPosition;
	private int itemAligner = 0;
	private string baseURL = "https://live.runmyprocess.com/";
	// Use this for initialization
	void Start () {
		processMenuTitle.text = "Test Process.";
		processBoxTitle.text = "Test Process.";

		StartCoroutine(GetText());

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// THIS PART IS ADOPTED FROM REQUESTING DATA FROM THE WEB REF.
	// DATE ACCESSED 17.11.2018.
	// EXAMPLE FROM OFFICIAL DOCUMENTATION.
	// INSPIRED BY TEAM 7 AR Project, Oliver Simon c1633899 20/11/2018
	IEnumerator GetText() {
		var username = "cristiano.bellucci.fujitsu+cardiffadmin@gmail.com";
		var password = "Millennium";


		var credentials = Convert.ToBase64String (Encoding.ASCII.GetBytes (username + ":" + password)); // FROM TEAM 7
		WWWForm form = new WWWForm();  // FROM TEAM 7
		var headers = form.headers;  // FROM TEAM 7
		headers ["Authorization"] = "Basic " + credentials;  // FROM TEAM 7
		headers ["Accept"] = "application/json";

		WWW www = new WWW("https://live.runmyprocess.com/live/112761542179152739/requestreport/CWL%20Market%20Campaign%20Report.csv?operator=EE%20EE%20IS&column=name%20status%20events%20published%20updated&value=215356%20ACCEPTANCE%20NULL&filter=PROJECT%20MODE%20PARENT&nb=20&first=0&method=GET&P_rand=34765", null, headers);

		yield return www;


		// Preparation for process step detail fetching.
		var jsonObject =  JSON.Parse(www.text);
		var arrayOfProcesses = jsonObject["feed"]["entry"].AsArray;

		// Getting process steps and details.
		foreach(var arrayItem in arrayOfProcesses.Values) {
			
			processMenuTitle.text = arrayItem["title"].Value;
			processBoxTitle.text = arrayItem["title"].Value;

			// Populate for ID b7dfe4e0-eccb-11e8-988a-0619bd984419
			if(arrayItem["id"] == "0bd5d740-eccb-11e8-894c-0639651b3341") {	
				// Getting process name and number.
				string processNameDetailURLPath = arrayItem["link"][0]["href"];

				WWW wwwForNameDetail = new WWW(baseURL + processNameDetailURLPath, null, headers);
				Debug.Log ("Request To " + baseURL + processNameDetailURLPath);

				yield return wwwForNameDetail;
				var detailNameJSON =  JSON.Parse(wwwForNameDetail.text);
				Debug.Log (wwwForNameDetail.text);

				name = JSON.Parse(wwwForNameDetail.text)["feed"]["entry"]["process"]["pool"]["lane"]["step"][1]["name"].Value;
				Debug.Log (name); // Debugging name of step 1.

				var processStepsArray =  JSON.Parse(wwwForNameDetail.text);
				var arrayOfRelatedSteps = processStepsArray["feed"]["entry"]["process"]["pool"]["lane"]["step"].AsArray;


				// Getting process details.
				string processDetailURLPath = arrayItem["content"]["src"];

				WWW wwwForDetail = new WWW(baseURL + processDetailURLPath, null, headers);
				Debug.Log ("Request To " + baseURL + processDetailURLPath);

				yield return wwwForDetail;
				var detailJSON =  JSON.Parse(wwwForDetail.text);

				var detailStatus =  JSON.Parse(www.text);
				var arrayOfStepDetails = jsonObject["feed"]["entry"]["content"]["P_value"]["path"].AsArray;

				int counter = 1;
				foreach (var stepItem in arrayOfRelatedSteps.Values) {
					if(stepItem["type"] == "activity") {
						createStep (stepItem["name"].Value, arrayOfStepDetails[counter]["st"], stepItem["action"]["service"]["request"]["assignedto"]["P_value"].Value,
							processStepsArray["feed"]["entry"]["process"]["pool"]["lane"]["name"]);
						counter++;
							
					}

				}
					


				// Getting step path.
				var arrayOfSteps = detailJSON["feed"]["entry"]["content"]["P_value"]["path"].AsArray;

				// Getting process step details.
				string furtherDetailsLink= detailJSON["feed"]["link"][10]["href"];

				Debug.Log ("Request For Further Details To " + baseURL + furtherDetailsLink);
				WWW wwwFurtherDetails = new WWW(baseURL + furtherDetailsLink, null, headers);

				yield return wwwFurtherDetails;
				var furtherDetailsJSON =  JSON.Parse(wwwFurtherDetails.text);


			}

		}
	}

	void createStep(string name, int status, string owner, string department, string comment = "No comment available.") {
		stepPrefab.GetComponentsInChildren<Text>()[0].text = name; // Step title.
		stepPrefab.GetComponentsInChildren<Text>()[1].text = name; // Step Box title.

		stepPrefab.GetComponentsInChildren<Text>()[3].text = department; // Step Department.
		stepPrefab.GetComponentsInChildren<Text>()[5].text = owner; // Step Owner.
		stepPrefab.GetComponentsInChildren<Text>()[4].text = comment; // Step Comment.

		// Setting parent game object of created child game objects.
		// Based on example https://answers.unity.com/questions/586985/how-to-make-an-instantiated-prefab-a-child-of-a-ga.html
		// Created by: robertbu · Dec 01, 2013 at 01:34 AM

		// BASED ON ANSWER BY pfreese · Mar 18, 2015 at 05:28 AM On "instantiating elements in UI/Canvas".
		// https://answers.unity.com/questions/926254/instantiating-elements-in-uicanvas.html
		// ACCESSED ON 22/11/2018

		if(status == 201) {
			stepPrefab.GetComponent<Image>().color = Color.yellow;

		} else if (status == 301) {
			stepPrefab.GetComponent<Image>().color = Color.red;

		} else if (status == 102) {
			stepPrefab.GetComponent<Image>().color = Color.green;

		}

		GameObject item = Instantiate(stepPrefab);
		item.transform.SetParent(stepParentObject.transform, false);

		item.transform.Translate(0,itemAligner,0);

		itemAligner -= 75;

	} 

	// End of referenced code.

}
