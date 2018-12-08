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


public class BackButton1 : MonoBehaviour {

    public Button BackToProjectsButton;

	// Use this for initialization
	void Start () {
        BackToProjectsButton.onClick.AddListener(FindIntroScreen);
	}
	
	
	

    

    void FindIntroScreen()
    {
        GameObject IntroScreen = GameObject.FindGameObjectWithTag("IntroScreen");
        IntroScreen.transform.SetAsLastSibling();       
    }
}
