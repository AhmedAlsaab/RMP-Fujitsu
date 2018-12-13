//using UnityEngine;
//using UnityEngine.TestTools;
//using NUnit.Framework;
//using System.Collections;
//using System.Text;
//using UnityEngine.UI;


//// REF: BASED ON UNITY DOCUMENTATION: https://docs.unity3d.com/Manual/testing-editortestsrunner.html
//// REF: BASED ON UNITY DOCUMENTATION: https://docs.unity3d.com/Manual/PlaymodeTestFramework.html
//// REF: BASED ON EXAMPLE https://www.youtube.com/watch?v=TyxDg70hc3g BY Infallible Code Published on Jul 4, 2017
//// ACCESSED ON 05/12/2018
//public class ProcessGenerationTest {
	
//	[Test]
//	public void ColorPickingPassing() {
//		ProcessDetailInserter testInsterter = new ProcessDetailInserter();

//		Color32 colourDefined = testInsterter.identifyStatus (201);

//		Color32 targetColor = new Color32(119, 157, 004, 255);

//		Assert.AreEqual (targetColor, colourDefined);
//	}

//	[Test]
//	public void ColorPickingFailed() {
//		ProcessDetailInserter testInsterter = new ProcessDetailInserter();

//		Color32 colourDefined = testInsterter.identifyStatus (301);

//		Color32 targetColor =  new Color32 (201, 47, 0, 255);

//		Assert.AreEqual (targetColor, colourDefined);
//	}

//	[Test]
//	public void ColorPickingPending() {
//		ProcessDetailInserter testInsterter = new ProcessDetailInserter();

//		Color32 colourDefined = testInsterter.identifyStatus (102);

//		Color32 targetColor = new Color32(217, 143, 0, 255);

//		Assert.AreEqual (targetColor, colourDefined);
//	}

//	[UnityTest]
//	public IEnumerator ProcessTitleAndHealth() {
//		ProcessDetailInserter testInsterter = new ProcessDetailInserter();
//		testInsterter.Construct ("Prefabs/Process Item","Prefabs/Step","Prefabs/Process Details General");

//		GameObject parentObj = new GameObject();
//		testInsterter.createProcess (parentObj, "Test Process", 201);

//		yield return null;

//		GameObject createdProcess = GameObject.FindGameObjectWithTag ("Process");

//		string title = createdProcess.GetComponentsInChildren<Text>()[0].text;

//		Color status1 = createdProcess.GetComponentsInChildren<Image> () [1].color;
//		Color status2 = createdProcess.GetComponentsInChildren<Image> () [3].color;

//		Color targetStatusColor = new Color32(119, 157, 004, 255);

//		Assert.AreEqual (title, "Test Process");
//		Assert.AreEqual (status1, targetStatusColor);
//		Assert.AreEqual (status2, targetStatusColor);
//	}

//	[UnityTest]
//	public IEnumerator StepTitleAndGeneration() {
//		ProcessDetailInserter testInsterter = new ProcessDetailInserter();
//		testInsterter.Construct ("Prefabs/Process Item","Prefabs/Step","Prefabs/Process Details General");

//		GameObject parentObj = new GameObject();
//		testInsterter.createProcess (parentObj, "Test Process", 201);

//		yield return null;

//		GameObject createdProcess = GameObject.FindGameObjectWithTag ("Process");

//		testInsterter.createStep (createdProcess, 0, "Test Step", 201, "Someone", "A Place");

//		GameObject createdStep = GameObject.FindGameObjectWithTag ("Step");

//		string title = createdStep.GetComponentsInChildren<Text> () [0].text;

//		Assert.AreEqual (title, "Test Step");
//	}

//	// END OF REFERENCED CODE
//}
