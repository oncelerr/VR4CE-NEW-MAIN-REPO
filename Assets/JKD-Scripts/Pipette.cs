using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipette : MonoBehaviour
{
    public GameObject waterDrop;
    public static bool _isHoldingPipette;
    public static bool _PipetteGotWater;

    // Timer Variables
    public float DipTime; 
    private bool isCountingDown = false; 
    private bool isPaused = false; 
    private bool alreadyGetDropWater;
    private bool alreadyDroppedWater;

    private void Start() 
    {
        _isHoldingPipette = false;
        alreadyGetDropWater = false;
        alreadyDroppedWater = false;
    }
    public void HoldingPipette(bool isHoldingPipette)
    {
        if(isHoldingPipette)
        {
            _isHoldingPipette = true;
        }
        else
        {
            _isHoldingPipette = false;
        }
    }

    private void Update() 
    {
        CheckPipette();
    }

    private void CheckPipette()
    {
        // Check if the pipette is dip with water
        if(WaterBeaker._PipeCollidedWithWater)
        {
            // 
            Timer("Start");
        }
        else
        {
            Timer("Pause");
        }

        // Check if Dip time is done
        if(DipTime <= 0 && !alreadyGetDropWater)
        {
            alreadyGetDropWater = true;
            waterDrop.SetActive(true);
            GameMngr.S2currentsteps = 4;
            vrRobot.currentStepExecuted2 = false;
            Debug.Log("Ready to drop!");
        }

        // Check if drop the water
        if(mixingBeakerDipArea.pippetteWaterDrop && !alreadyDroppedWater)
        {
            alreadyDroppedWater = true;
            waterDrop.SetActive(false);
            Debug.Log("Already drop the water");
        }
    }
    private void Timer(string State)
    {
        // Check if the countdown is active and not paused
        if (isCountingDown && !isPaused)
        {
            // Update the current time based on the elapsed time since the last frame
            DipTime -= Time.deltaTime;

            // Check if the countdown has reached zero
            if (DipTime <= 0f)
            {
                DipTime = 0f; // Ensure the current time is not negative   
                // Debug.Log("Countdown finished!");
                isCountingDown = false; // Stop the countdown
            }

            // Display the current time (rounded to 2 decimal places) in the console
            // Debug.Log("Time left: " + DipTime.ToString("F2"));
        }
        if(State == "Start")
        {
            // Start the countdown
            isCountingDown = true;
            isPaused = false; // Ensure the countdown is not paused
            // Debug.Log("Timer Started");
        }
        else if(State == "Stop")
        {
            // Stop the countdown
            isCountingDown = false;
            isPaused = false; // Ensure the countdown is not paused
            // Debug.Log("Timer Stop");
        }
        else if(State == "Pause")
        {
            // Pause the countdown
            isPaused = true;
            // Debug.Log("Timer Paused");
        }
        else
        {
            Debug.LogError("Invalid timer parameter");
        }
    }
}
