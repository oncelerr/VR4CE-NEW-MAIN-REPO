using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using DG.Tweening;


public class ValveHose : MonoBehaviour
{
    [SerializeField] AudioMngr _AudioMngr;
    [SerializeField] vrRobot _vrRobot;
    [SerializeField] GameObject _rotationGuide;
    [SerializeField] GameObject _arrowGuide;
    public XRKnob knob;
    public Transform rotationGuide;
    public static bool isValveCorrect;
    private bool valveAlreadySet;
    private bool holdingTheValve;
    private bool alreadyCheckifClose;
    private bool alreadyRemindedValve;
    private float timeRemaining = 60f;

    private void Start() 
    {
        // Reset variables
        isValveCorrect = false;
        valveAlreadySet = false;
        holdingTheValve = false;
        alreadyCheckifClose = false;
        alreadyRemindedValve = false;
    }
    void Update()
    {
        if(GameMngr.CurrentLevelIndex == 1)
        {
            // Debug.Log("The knob value is: "+knob.value);
            // Calculate the target rotation based on the slider's value
            float targetRotation = knob.value * 360f;
            // Rotate the object around its up axis based on the slider's value
            rotationGuide.localEulerAngles = new Vector3(90f, targetRotation, 0f);
            // Invoke("ValveControl", .7f);
            ValveControl();
        }
    }

    public void ValveControl()
    {
        if(GameMngr.S1currentsteps == 1f && holdingTheValve && !valveAlreadySet && knob.value >= 0.05f && knob.value <= 0.08f)
        {
            isValveCorrect = true;
            valveAlreadySet = true;
            GameMngr.S1currentsteps = 2f;
            vrRobot.currentStepExecuted = false;
            Debug.Log("Already set the correct valve clearance.");
        }
        // else if(GameMngr.S1currentsteps == 1f && holdingTheValve && !valveAlreadySet && knob.value > 0.08f)
        // {
        //     valveAlreadySet = true;
        //     isValveCorrect = false;
        // }
        else if(GameMngr.S1currentsteps == 2f && holdingTheValve && !valveAlreadySet && knob.value > 0.08f)
        {
            valveAlreadySet = true;
            isValveCorrect = false;
        }

        // Check if the valve is close
        if(holdingTheValve && valveAlreadySet && !alreadyCheckifClose)
        {
            if(knob.value == 0f)
            {
                alreadyCheckifClose = true;
                _AudioMngr.CollectedPointFX();
                _AudioMngr.VRBotNice();
                UIMngr.currentProgress += 14f;
                // Already close the valve
                // Added points
            }
        }
        if(!alreadyRemindedValve && valveAlreadySet && GameMngr.alreadyReachLastStep)
        {
            alreadyRemindedValve = true;
            RemindToCloseValve();
        }
    }
    
    public void ShowGuide(bool state)
    {
        _rotationGuide.SetActive(state);
        _arrowGuide.SetActive(state);
        holdingTheValve = state;
    }

    public void RemindToCloseValve()
    {
        if(!alreadyCheckifClose)
        {
            Sequence step = DOTween.Sequence();
            step.AppendCallback(() => _AudioMngr.ForgetToCloseValve()); // s19
            step.AppendInterval(60f); // Delay
            step.Play(); 
        }
    }
}
