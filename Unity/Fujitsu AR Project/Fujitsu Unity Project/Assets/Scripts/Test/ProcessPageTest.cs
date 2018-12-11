using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class ProcessPageTest {


	[Test]
	public void ClickNextIncrementsStartBy5() {
		ProcessPages testInstance = new ProcessPages ();

		testInstance.numberOfProcesses = 23;

		Assert.AreEqual (5, testInstance.GetPageNumber (0, "next"));
	}

	[Test]
	public void ClickBackDecrementsStartBy5() {
		ProcessPages testInstance = new ProcessPages ();

		testInstance.numberOfProcesses = 23;

		Assert.AreEqual (0, testInstance.GetPageNumber (5, "back"));
	}

	[Test]
	public void ClickBackWhenStartIsZeroReturnsZero() {
		ProcessPages testInstance = new ProcessPages ();

		testInstance.numberOfProcesses = 23;

		Assert.AreEqual (0, testInstance.GetPageNumber (0, "back"));
	}

	[Test]
	public void ClickNextWhenThereAreNoMoreProcessesToDisplayDoesNotIncrementStart() {
		ProcessPages testInstance = new ProcessPages ();

		testInstance.numberOfProcesses = 23;

		Assert.AreEqual (20, testInstance.GetPageNumber (20, "next"));
	}
}
