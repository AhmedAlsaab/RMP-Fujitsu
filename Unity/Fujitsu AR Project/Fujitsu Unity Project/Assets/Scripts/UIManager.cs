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

         try
        {
            ProjectItemArray = GameObject.FindGameObjectsWithTag("Process");

            if (ProjectItemArray.Length > 4) //size u want
            {
                
                if (ProcessAssignerCalled == false)
                {
                    
                    ProcessBtnAssigner();
                }
            }
        }
        catch (IndexOutOfRangeException e)
        {
            //print error if u want
        }

        try
        {
            ProcessDetailsBackBtnArray = GameObject.FindGameObjectsWithTag("ProcessDetail");

            if (ProcessDetailsBackBtnArray.Length > 4) //size u want
            {
                
                if (ProcessDetailsBackAssignerCalled == false)
                {
                    
                    ProcessDetailsGeneralBackBtn();
                }
            }
        }
        catch (IndexOutOfRangeException e)
        {
            //print error if u want
        }
    }





    void ProcessDetailsGeneralBackBtn()
    {
        foreach (GameObject game in ProcessDetailsBackBtnArray)
        {
           
            game.GetComponentsInChildren<Button>()[0].onClick.AddListener(HideProcessDetailsGeneral);
        }
        ProcessDetailsBackAssignerCalled = true;
    }

    void ProcessBtnAssigner()
    {
        foreach (GameObject game in ProjectItemArray)
        {
            game.GetComponentsInChildren<Button>()[0].onClick.AddListener(ShowProcessDetailsGeneral);
            
        }
        ProcessAssignerCalled = true;
    }

    void ProjectBtnAssigner()
    {

           ProjectButtonArray[0].GetComponentsInChildren<Button>()[0].onClick.AddListener(ShowCampaignListButton);
           ProjectButtonArray[1].GetComponentsInChildren<Button>()[0].onClick.AddListener(ShowFairListButton);
           BtnAssignerCalled = true;
    }

    // Update is called once per frame
    public void ShowCampaignListButton()
    {
        MainMenu.DOAnchorPos(new Vector2(-5000, 0), 0.35f);
        CampaignMenu.DOAnchorPos(new Vector2(0, 0), 0.35f);
    }

     public void ShowFairListButton()
    {
        MainMenu.DOAnchorPos(new Vector2(-5000, 0), 0.35f);
        FairMenu.DOAnchorPos(new Vector2(0, 0), 0.35f);
    }

    public void HideCampaignProcess()
    {
        MainMenu.DOAnchorPos(new Vector2(0, 0), 0.35f);
        CampaignMenu.DOAnchorPos(new Vector2(5000, 0), 0.35f);
        FairMenu.DOAnchorPos(new Vector2(5000, 0), 0.35f);
    }

    public void ShowProcessDetailsGeneral()
    {

        ProcessDetailsPrefab.DOAnchorPos(new Vector2(0, -2000), 0.35f);
        Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");


    }

    public void HideProcessDetailsGeneral()
    {

        ProcessDetailsPrefab.DOAnchorPos(new Vector2(0, 0), 0.35f);
        Debug.Log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");


    }
}
