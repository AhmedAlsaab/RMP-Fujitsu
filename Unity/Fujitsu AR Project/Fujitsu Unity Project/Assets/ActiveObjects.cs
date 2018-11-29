using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjects : MonoBehaviour {
    public GameObject Popup;
    public GameObject IntroScreen;

	// Use this for initialization
	void Start () {
        Popup.SetActive(false);
        Popup.transform.SetAsLastSibling();


        IntroScreen.SetActive(true);
    }

    // Update is called once per frame
    void Update () {

    }
}
