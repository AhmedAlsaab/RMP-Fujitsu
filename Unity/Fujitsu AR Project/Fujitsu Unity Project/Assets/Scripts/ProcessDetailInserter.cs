using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	public int numberOfSteps;
	public Transform stepSpawnPosition;
	private int i = 0;
	private int itemAligner = 0;
	// Use this for initialization
	void Start () {
		processMenuTitle.text = "Test Process.";
		processBoxTitle.text = "Test Process.";

	}
	
	// Update is called once per frame
	void Update () {
		if(i < numberOfSteps) {
			stepPrefab.GetComponentsInChildren<Text>()[0].text = "Step " + (i + 1).ToString(); // Step title.
			stepPrefab.GetComponentsInChildren<Text>()[1].text = "Step " + (i + 1).ToString(); // Step Box title.
			stepPrefab.GetComponentsInChildren<Text>()[3].text = "Step " + (i + 1).ToString() + " Department."; // Step Department.
			stepPrefab.GetComponentsInChildren<Text>()[5].text = "Step " + (i + 1).ToString() + " Owner."; // Step Owner.
			stepPrefab.GetComponentsInChildren<Text>()[4].text = "Step " + (i + 1).ToString() + " Details."; // Step Comment.

			// Setting parent game object of created child game objects.
			// Based on example https://answers.unity.com/questions/586985/how-to-make-an-instantiated-prefab-a-child-of-a-ga.html
			// Created by: robertbu · Dec 01, 2013 at 01:34 AM

			// BASED ON ANSWER BY pfreese · Mar 18, 2015 at 05:28 AM On "instantiating elements in UI/Canvas".
			// https://answers.unity.com/questions/926254/instantiating-elements-in-uicanvas.html
			// ACCESSED ON 22/11/2018
			GameObject item = Instantiate(stepPrefab);
			item.transform.SetParent(stepParentObject.transform, false);

			item.transform.Translate(0,itemAligner,0);

			itemAligner -= 75;
			i++;

		}
	}
}

// End of referenced code.