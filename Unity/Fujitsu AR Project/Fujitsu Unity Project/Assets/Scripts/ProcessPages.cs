using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;
using System.Text;
using SimpleJSON;

public class ProcessPages : MonoBehaviour {

	// http://wiki.unity3d.com/index.php/SimpleJSON

	int start = 0;

	public int numberOfProcesses = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnBackButtonClick(){
		StartCoroutine (GetNumberOfProcesses ("back"));
	}

	public void OnNextButtonClick(){
		StartCoroutine (GetNumberOfProcesses ("next"));
	}

	// This code has been copied and adapted from the code written by Arda Karaderi in ProcessDetailInserter.cs
	IEnumerator GetNumberOfProcesses(string type) {
		var username = "cristiano.bellucci.fujitsu+cardiffadmin@gmail.com";
		var password = "Millennium";

		var credentials = Convert.ToBase64String (Encoding.ASCII.GetBytes (username + ":" + password));
		WWWForm form = new WWWForm();
		var headers = form.headers;
		headers ["Authorization"] = "Basic " + credentials;
		headers ["Accept"] = "application/json";

		WWW www = new WWW("https://live.runmyprocess.com/live/112761542179152739/requestreport/CWL%20Market%20Campaign%20Report.csv?operator=EE%20EE%20IS&column=name%20status%20events%20published%20updated&value=215356%20ACCEPTANCE%20NULL&filter=PROJECT%20MODE%20PARENT&nb=20&first=0&method=GET&P_rand=34765", null, headers);

		yield return www;

		var jsonObject =  JSON.Parse(www.text);
		var arrayOfProcesses = jsonObject["feed"]["entry"].AsArray;

		numberOfProcesses = arrayOfProcesses.Count;

		ChangeFile (type);
	}

	public void ChangeFile(string type) {
		int currentPage = Convert.ToInt32(File.ReadAllText ("Assets/Scripts/processPage.txt"));

		start = GetPageNumber (currentPage, type);

		// File.WriteAllText Method
		// https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealltext?view=netframework-4.7.2
		// Accessed 9/12/2018
		File.WriteAllText ("Assets/Scripts/processPage.txt", start.ToString());
	}
		
	public int GetPageNumber(int currentProcessStart, string type) {

		if (type == "back") {
			if (currentProcessStart != 0) {
				currentProcessStart -= 5;
			} 
		}

		if (type == "next") {
			if (currentProcessStart + 5 < numberOfProcesses) {
				currentProcessStart += 5;
			} 
		}

		return currentProcessStart;
	}

	public void ResetPageNumber(){
		// File.WriteAllText Method
		// https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writealltext?view=netframework-4.7.2
		// Accessed 9/12/2018
		File.WriteAllText ("Assets/Scripts/processPage.txt", "0");
	}
		
}
