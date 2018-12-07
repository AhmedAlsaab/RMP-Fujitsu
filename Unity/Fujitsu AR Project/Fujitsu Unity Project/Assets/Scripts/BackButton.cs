using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour {

    public GameObject ProjectScreen;
    public Button backButton;
	// Use this for initialization
	void Start () {

        backButton.onClick.AddListener(GoBackToProjectsScreen);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GoBackToProjectsScreen()
    {
        ProjectScreen.transform.SetAsLastSibling();
        Debug.Log("YOU ARE CLICKING");
    }
}
