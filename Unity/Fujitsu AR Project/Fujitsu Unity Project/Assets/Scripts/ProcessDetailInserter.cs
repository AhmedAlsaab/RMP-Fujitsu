﻿using System.Collections;
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
	public GameObject stepPrefab;

	private string baseURL = "https://live.runmyprocess.com/";

	private int processAligner = 0;
	public GameObject processPrefab;
	public GameObject processParent;

	private int processLimit = 5;

	public GameObject stepsHolderPrefab;


	// Use this for initialization
	void Start () {
		StartCoroutine(HandleJSON());

	}


	// THIS PART IS ADOPTED FROM REQUESTING DATA FROM THE WEB REF.
	// DATE ACCESSED 17.11.2018.
	// EXAMPLE FROM OFFICIAL DOCUMENTATION.
	// LOGIN HEADER INSPIRED BY TEAM 7 AR Project, Oliver Simon c1633899 20/11/2018
	public IEnumerator HandleJSON() {
		var username = "cristiano.bellucci.fujitsu+cardiffadmin@gmail.com";
		var password = "Millennium";


		var credentials = Convert.ToBase64String (Encoding.ASCII.GetBytes (username + ":" + password)); // FROM TEAM 7
		WWWForm form = new WWWForm();  // FROM TEAM 7
		var headers = form.headers;  // FROM TEAM 7
		headers ["Authorization"] = "Basic " + credentials;  // FROM TEAM 7
		headers ["Accept"] = "application/json";

		WWW www = new WWW("https://live.runmyprocess.com/live/112761542179152739/requestreport/CWL%20Market%20Campaign%20Report.csv?operator=EE%20EE%20IS&column=name%20status%20events%20published%20updated&value=215356%20ACCEPTANCE%20NULL&filter=PROJECT%20MODE%20PARENT&nb=20&first=0&method=GET&P_rand=34765", null, headers);

		yield return www;


		// Preparation for process generation.
		var jsonObject =  JSON.Parse(www.text);
		var arrayOfProcesses = jsonObject["feed"]["entry"].AsArray;

		int i = 0;

		// Getting the process report.
		foreach(var arrayItem in arrayOfProcesses.Values) {
			if(i < processLimit) {

				GameObject createdProcess = createProcess (arrayItem["title"].Value, arrayItem["category"][0]["label"].AsInt);

				// Adding in title for process.
				createdProcess.GetComponentsInChildren<Text>()[0].text = arrayItem["title"].Value;

				// Getting process name and number.
				string processNameDetailURLPath = arrayItem["link"][0]["href"];

				WWW wwwForNameDetail = new WWW(baseURL + processNameDetailURLPath, null, headers);
				Debug.Log ("Request To " + baseURL + processNameDetailURLPath);

				yield return wwwForNameDetail;

				var processStepsArray =  JSON.Parse(wwwForNameDetail.text);
				var arrayOfRelatedSteps = processStepsArray["feed"]["entry"]["process"]["pool"]["lane"]["step"].AsArray;


				// Getting process details.
				string processDetailURLPath = arrayItem["content"]["src"];

				WWW wwwForDetail = new WWW(baseURL + processDetailURLPath, null, headers);
				Debug.Log ("Request To " + baseURL + processDetailURLPath);

				yield return wwwForDetail;
				var detailJSON =  JSON.Parse(wwwForDetail.text);

				var arrayOfStepDetails = detailJSON["feed"]["entry"]["content"]["P_value"]["path"].AsArray;

				int counter = 0;
				int itemAligner = 0;
				foreach (var stepItem in arrayOfRelatedSteps.Values) {
					if(stepItem["type"] == "activity") {
						createStep(createdProcess, itemAligner, stepItem["name"].Value, arrayOfStepDetails[counter]["st"], stepItem["action"]["service"]["request"]["assignedto"]["P_value"].Value,
							processStepsArray["feed"]["entry"]["process"]["pool"]["lane"]["name"]);
						
						itemAligner -= 75;
					}
					counter++;
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

			i++;

		}
	}


	public void createStep(GameObject parent, int position, string name, int status, string owner, string department, string comment = "No comment available.") {
		stepPrefab.GetComponentsInChildren<Text>()[0].text = name; // Step Main Button title.
		stepPrefab.GetComponentsInChildren<Text>()[1].text = name; // Step Pop Up Box title.

		stepPrefab.GetComponentsInChildren<Text>()[3].text = department; // Step Department.
		stepPrefab.GetComponentsInChildren<Text>()[5].text = owner; // Step Owner.
		stepPrefab.GetComponentsInChildren<Text>()[4].text = comment; // Step Comment.

		// Setting parent game object of created child game objects.
		// Based on example https://answers.unity.com/questions/586985/how-to-make-an-instantiated-prefab-a-child-of-a-ga.html
		// Created by: robertbu · Dec 01, 2013 at 01:34 AM

		// BASED ON ANSWER BY pfreese · Mar 18, 2015 at 05:28 AM On "instantiating elements in UI/Canvas".
		// https://answers.unity.com/questions/926254/instantiating-elements-in-uicanvas.html
		// ACCESSED ON 22/11/2018
		GameObject item = Instantiate(stepPrefab);
		item.transform.SetParent(parent.transform.GetChild(2), false);

		item.transform.Translate(0, position, 0);
		item.transform.GetChild(1).Translate(0, (position * -1), 0);

		// Setting color of the Step
		item.GetComponent<Image>().color = identifyStatus(status);

	} 


	// Setting parent game object of created child game objects.
	// Based on example https://answers.unity.com/questions/586985/how-to-make-an-instantiated-prefab-a-child-of-a-ga.html
	// Created by: robertbu · Dec 01, 2013 at 01:34 AM

	// BASED ON ANSWER BY pfreese · Mar 18, 2015 at 05:28 AM On "instantiating elements in UI/Canvas".
	// https://answers.unity.com/questions/926254/instantiating-elements-in-uicanvas.html
	// ACCESSED ON 22/11/2018
	public GameObject createProcess(string processTitle, int status) {
		GameObject individualProcess = Instantiate(processPrefab);
		individualProcess.transform.SetParent(processParent.transform, false);

		individualProcess.transform.Translate(0, processAligner, 0);

		GameObject processStepHolder = Instantiate(stepsHolderPrefab);
		processStepHolder.transform.SetParent(individualProcess.transform, false);

		// REF: DOCUMENTATION: https://docs.unity3d.com/ScriptReference/Transform.GetChild.html
		// CONVERTING TO POSITIVE https://stackoverflow.com/questions/1348080/convert-a-positive-number-to-negative-in-c-sharp
		// BY Shimmy at Jan 24 '12 at 23:13 ACCESSED ON 28/11/2018
		individualProcess.transform.GetChild(2).Translate(0, (processAligner * -1), 0);


		processAligner -= 75;


		individualProcess.GetComponentsInChildren<Text>()[0].text = processTitle;

		// Setting colors of Process Health Display.
		individualProcess.GetComponentsInChildren<Image>()[1].color = identifyStatus(status);
		individualProcess.GetComponentsInChildren<Image>()[3].color = identifyStatus(status);

		return processStepHolder;
	} 


	public Color32 identifyStatus(int status) {
		Color32 colorCode = new Color32(217, 143, 0, 255);

		// Success colour
		if(status == 201) {
			colorCode = new Color32(119, 157, 004, 255);

		// Pending colour
		} else if (status == 301) {
			colorCode = new Color32(201, 47, 0, 255);

		// Failed colour
		} else if (status == 102) {
			colorCode = new Color32(217, 143, 0, 255);

		}

		return colorCode;
	} 
	// End of referenced code.

}
