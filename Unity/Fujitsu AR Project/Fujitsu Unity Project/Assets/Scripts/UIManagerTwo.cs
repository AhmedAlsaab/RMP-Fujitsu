using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;

public class UIManagerTwo : MonoBehaviour
{

    public RectTransform TestPrefab;




              void Start() {

            }
    

             public void TestingOnClick()
                {
                    TestPrefab.DOAnchorPos(new Vector2(-3000, 0), 0.35f);
                }
}
