using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;



//C1443907
// REF: UI TWEENING
// https://www.youtube.com/watch?v=xKso4D6T8Sk 

public class UIManager : MonoBehaviour {

    public RectTransform MainMenu, CampaignMenu, FairMenu, GlobalButtons;
    public GameObject[] ProjectButtonArray;
    public GameObject[] ProjectItemArray;
    public GameObject[] ProcessDetailsBackBtnArray;
    private bool BtnAssignerCalled = false;
    private bool ProcessAssignerCalled = false;
    private bool ProcessDetailsBackAssignerCalled = false;
    public RectTransform ProcessDetailsPrefab;
    public RectTransform StepPrefab;



    void Start() {

    }
    // Needs to be in update method as tags are allocated post-launch, when API data fetches
     void Update()
    {
        // Try block as Index will be out of range untill data is passed in by API
        try
        {
            ProjectButtonArray = GameObject.FindGameObjectsWithTag("ProjectBtn");
            // If tag has been found:
            if (ProjectButtonArray.Length > 1) 
            {
                // If the method has not been run yet, making sure the update method won't continously run it
                if (BtnAssignerCalled == false)
                {
                    
                    ProjectBtnAssigner();
                }
            }
        }
        catch (IndexOutOfRangeException e)
        {
            //print error if u want
        }

    }
    //C1443907

    // Assigning onclick listeners to each project
    // Transition corresponding panels into view when selected
    void ProjectBtnAssigner()
    {

           ProjectButtonArray[0].GetComponentsInChildren<Button>()[0].onClick.AddListener(ShowCampaignListButton);
           ProjectButtonArray[1].GetComponentsInChildren<Button>()[0].onClick.AddListener(ShowFairListButton);
        // Set to true so that when method has been run in the update block, it won't run again as it's now true (changed from false)
           BtnAssignerCalled = true;
        
    }

    // Change anchor positions of specified elements when this method is run
    // 0.35f is the speed of transition
    public void ShowCampaignListButton()
    {
        MainMenu.DOAnchorPos(new Vector2(-5000, 0), 0.35f);
        CampaignMenu.DOAnchorPos(new Vector2(0, 0), 0.35f);
        
    }
    // Change anchor positions of specified elements when this method is run
     public void ShowFairListButton()
    {
        MainMenu.DOAnchorPos(new Vector2(-5000, 0), 0.35f);
        FairMenu.DOAnchorPos(new Vector2(0, 0), 0.35f);
        
    }
    // Change anchor positions of specified elements when this method is run
    public void HideCampaignProcess()
    {
        MainMenu.DOAnchorPos(new Vector2(0, 0), 0.35f);
        CampaignMenu.DOAnchorPos(new Vector2(5000, 0), 0.35f);
        FairMenu.DOAnchorPos(new Vector2(5000, 0), 0.35f);
        
    }
    // Change anchor positions of specified elements when this method is run
    public void HideGlobalButtons()
    {
        GlobalButtons.DOAnchorPos(new Vector2(2000, 0), 0.35f);
    }
    // Change anchor positions of specified elements when this method is run
    public void ShowGlobalButtons()
    {
        GlobalButtons.DOAnchorPos(new Vector2(0, 0), 0.35f);
    }
   
}
