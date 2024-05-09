using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using DG.Tweening;


public class s5TestTubeHolder : MonoBehaviour
{
    private bool _testtubeSnapperDone;
    public static int S5testtubeholderIndex;
    public static int testtubeholderIndexPC;


    private void Start() 
    {
        _testtubeSnapperDone = false;
    }
    
    public void TestTubeSetUp(bool state) 
    {
        if(state && !_testtubeSnapperDone && GameMngr.S5currentsteps == 1)
        {
            _testtubeSnapperDone = true;
            GameMngr.S5currentsteps = 2;
            vrRobot.currentStepExecuted5 = false;
        }
    }
}
