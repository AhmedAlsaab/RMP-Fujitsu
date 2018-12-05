using System.Collections.Generic;
using System.Collections;
using Vuforia;
using UnityEngine;

public class ProjectScreen : MonoBehaviour, ITrackableEventHandler {

    public GameObject MarketingCanvas;

    private TrackableBehaviour trackableBehaviour;

    private bool ShowGUIButton = false;
    private Rect ButtonRect = new Rect(50, 50, 120, 60);
	
	// Use this for initialization
	void Start () {
        trackableBehaviour = GetComponent<TrackableBehaviour>();
        if (trackableBehaviour)
        {
            trackableBehaviour.RegisterTrackableEventHandler(this);
        }

		
	}

    void Update()
    {
                        // MarketingCanvas.SetActive(false);

    }

    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED  ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            ShowGUIButton = true;
            // MarketingCanvas.SetActive(true);
            // Debug.Log("Canvas set to active");
        }
        else if(previousStatus == TrackableBehaviour.Status.TRACKED && newStatus == TrackableBehaviour.Status.NOT_FOUND 
             || previousStatus == TrackableBehaviour.Status.EXTENDED_TRACKED && newStatus == TrackableBehaviour.Status.NOT_FOUND)
        {
            Debug.Log("canvas set to true");
            ShowGUIButton = true;
            // MarketingCanvas.SetActive(true);

        }
        else 
        {
            ShowGUIButton = false;
            // MarketingCanvas.SetActive(false);
            Debug.Log("canvas set to false");

        }
       
    }

    void OnGUI()
    {
        if (ShowGUIButton)
        {
        
            GUI.Button(ButtonRect, "Hello");
            
        }
    }
	
}
