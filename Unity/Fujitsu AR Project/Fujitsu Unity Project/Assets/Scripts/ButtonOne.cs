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
using Vuforia;

public class ButtonOne : MonoBehaviour
{

    public RectTransform MainMenu, CampaignMenu, FairMenu;


    private void OnMouseDown()
    {
        ShowFairListButton();
    }

    public void ShowFairListButton()
    {
        MainMenu.DOAnchorPos(new Vector2(-5000, 0), 0.35f);
        FairMenu.DOAnchorPos(new Vector2(0, 0), 0.35f);
    }

}
