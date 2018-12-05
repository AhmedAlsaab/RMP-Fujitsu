using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ProcessGenerationTest {
	
	[Test]
	public void ColorPickingPassing() {
		ProcessDetailInserter testInsterter = new ProcessDetailInserter();

		Color32 colourDefined = testInsterter.identifyStatus (201);

		Color32 targetColor = new Color32(119, 157, 004, 255);

		Assert.AreEqual (targetColor, colourDefined);
	}

	[Test]
	public void ColorPickingFailed() {
		ProcessDetailInserter testInsterter = new ProcessDetailInserter();

		Color32 colourDefined = testInsterter.identifyStatus (301);

		Color32 targetColor = new Color32(217, 143, 0, 255);

		Assert.AreEqual (targetColor, colourDefined);
	}

	[Test]
	public void ColorPickingPending() {
		ProcessDetailInserter testInsterter = new ProcessDetailInserter();

		Color32 colourDefined = testInsterter.identifyStatus (102);

		Color32 targetColor = new Color32 (201, 47, 0, 255);

		Assert.AreEqual (targetColor, colourDefined);
	}
}
