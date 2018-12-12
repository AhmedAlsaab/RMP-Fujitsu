using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;
using System.Text;
using SimpleJSON;



// REF: UI TWEENING
// https://www.youtube.com/watch?v=xKso4D6T8Sk 

public class UIManager : MonoBehaviour {

    public RectTransform MainMenu, CampaignMenu, FairMenu;
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

     void Update()
    {

        try
        {
            ProjectButtonArray = GameObject.FindGameObjectsWithTag("ProjectBtn");

            if (ProjectButtonArray.Length > 1) //size u want
            {
                
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




    // BACK BUTTON 
 

   
    
    // ASSIGNING ONCLICK METHODS FOR INDICATED INDEX ONTO BUTTON FOUND IN THE ARRAY
    void ProjectBtnAssigner()
    {

           ProjectButtonArray[0].GetComponentsInChildren<Button>()[0].onClick.AddListener(ShowCampaignListButton);
           ProjectButtonArray[1].GetComponentsInChildren<Button>()[0].onClick.AddListener(ShowFairListButton);
           BtnAssignerCalled = true;
        Debug.Log("111111111111111111111111111111");
    }

    
    public void ShowCampaignListButton()
    {
        MainMenu.DOAnchorPos(new Vector2(-5000, 0), 0.35f);
        CampaignMenu.DOAnchorPos(new Vector2(0, 0), 0.35f);
        Debug.Log("2222222222222222222222");
    }

     public void ShowFairListButton()
    {
        MainMenu.DOAnchorPos(new Vector2(-5000, 0), 0.35f);
        FairMenu.DOAnchorPos(new Vector2(0, 0), 0.35f);
        Debug.Log("333333333333333333333333333");
    }

    public void HideCampaignProcess()
    {
        MainMenu.DOAnchorPos(new Vector2(0, 0), 0.35f);
        CampaignMenu.DOAnchorPos(new Vector2(5000, 0), 0.35f);
        FairMenu.DOAnchorPos(new Vector2(5000, 0), 0.35f);
        Debug.Log("4444444444444444444444444444444444444");
    }

   
}
