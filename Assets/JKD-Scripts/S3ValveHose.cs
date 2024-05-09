using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using DG.Tweening;


public class S3ValveHose : MonoBehaviour
{
    [SerializeField] ParticleSystem[] _WhiteSmoke;
    public Timer _Timer;
    public S3Burner _S3Burner;
    public XRKnob knob;
    private bool alreadySetValve;
    private bool alreadySetValve2;
    private bool alreadySetValve3;
    public static bool S3ValveTurnedON;

    private void Start() 
    {
        // Reset variables
        alreadySetValve = false;
        alreadySetValve2 = false;
        alreadySetValve3 = false;
        S3ValveTurnedON = false;
    }
    void Update()
    {
        // 
        if(knob.value > 0.20f && knob.value < 0.30f && !alreadySetValve && GameMngr.S3currentsteps == 3)
        {
            alreadySetValve = true;
            S3ValveTurnedON = true;
            GameMngr.S3currentsteps = 4;
            vrRobot.currentStepExecuted3 = false;
            Debug.Log("Valve turned ON!");
        }

        if(knob.value > 0.70f && !alreadySetValve2  && GameMngr.S3currentsteps == 5)
        {
            alreadySetValve2 = true;
            S3ValveTurnedON = true;
            // Get the current main module of the particle system
            var mainModule = _S3Burner.s3BurnerFire.main;

            // Decrease the start lifetime by the specified amount
            mainModule.startLifetime = Mathf.Max(mainModule.startLifetime.constant + S3Burner.s3BurnerFireAmount, 0f);
            
            Debug.Log("Valve 2 set ON!");
            _Timer.StartCountUpTimer(0f,10f);
            _WhiteSmoke[s3TestTubeHolder.testtubeholderIndex].Play();
        }

        if(knob.value <= 0.10f && !alreadySetValve3 && GameMngr.S3currentsteps == 6)
        {
            alreadySetValve3 = true;
            GameMngr.S3currentsteps = 7;
            vrRobot.currentStepExecuted3 = false;
            _S3Burner.s3BurnerFire.Stop(); //Stop the fire

            // Decrease the smoke emission
            var emission = _WhiteSmoke[s3TestTubeHolder.testtubeholderIndex].emission;
            emission.rateOverTime = Mathf.Lerp(25, 10, 0);
            Debug.Log("Valve turned OFF!");
        }
    }
}
