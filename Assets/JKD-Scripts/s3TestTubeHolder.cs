using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using DG.Tweening;


public class s3TestTubeHolder : MonoBehaviour
{
    private bool _testtubeSnapperDone;
    public static int testtubeholderIndex;

    private void Start() 
    {
        _testtubeSnapperDone = false;
    }
    
    public void TestTubeSetUp(bool state) 
    {
        if(state && !_testtubeSnapperDone && GameMngr.S3currentsteps == 2)
        {
            _testtubeSnapperDone = true;
            GameMngr.S3currentsteps = 3;
            vrRobot.currentStepExecuted3 = false;
            // Debug.Log("Test "+s3TestTubeContent.whichtestubeisHolding+" tube already set.");
        }
    }
}
