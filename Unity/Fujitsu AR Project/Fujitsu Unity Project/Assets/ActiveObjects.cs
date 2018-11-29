using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjects : MonoBehaviour {
    public GameObject Popup;
    public GameObject IntroScreen;
    public GameObject CampaignProcesses;
    public GameObject FairProcesses;


	// Use this for initialization
	void Start () {
        Popup.SetActive(false);
        Popup.transform.SetAsLastSibling();

        IntroScreen.SetActive(true);

        CampaignProcesses.SetActive(false);
        FairProcesses.SetActive(false);


    }

    // Update is called once per frame
    void Update () {

    }
}
