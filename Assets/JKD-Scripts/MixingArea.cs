using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingArea : MonoBehaviour
{
    // Scripts
    [SerializeField] mixingBeakerContent _mixingBeakerContent;

    public GameObject mBeakerIodineCont;
    public GameObject mBeakerAlumCont;

    public GameObject[] _PhasesObj;

    // mixing area following the empty beaker
    public Transform mixingBeaker;
    public Transform mixingArea;
    public static bool _isHoldingStirrRod;
    public static bool isMixingDone;
    public float angleThreshold2;
    private bool stirringStarted;


    // Timer Variables
    public float countdownTime = 10f; // The countdown time in seconds
    public static float currentTimer; // The current time left in the countdown
    private bool isCountingDown = false; // Flag to indicate if the countdown is active
    private bool isPaused = false; // Flag to indicate if the countdown is paused
    private bool alumAlreadyTurnOff = false; // 1st step
    private bool _1stPhaseDone = false; // 2nd
    private bool _2ndPhaseDone = false; // 3rd


    // Check transfer success variables
    private bool bothPowderTransferredSuccess;
    private bool activatedTransferState;

    
    private void Start() 
    {
        // Initialize the current time to the countdown time
        currentTimer = countdownTime;
        // Initialize variables
        _isHoldingStirrRod = false;
        isMixingDone = false;
        stirringStarted = false;
        bothPowderTransferredSuccess = false;
        activatedTransferState = false;
    }

    private void Update()
    {
        CheckTransferState();
        Timer();
        MixingProcess();
        // Follow empty beaker`s location
        FollowObject2(mixingBeaker, mixingArea);

        // Check if the player is not mixing; pause the timer
        if(!StirringRod._isHoldingStirrRod)
        {
            PauseCountdown();
        }

    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag("StirrRod"))
        {
            if(StirringRod._isHoldingStirrRod && bothPowderTransferredSuccess)
            {
                StartCountdown();
                
                if(!stirringStarted)
                {
                    stirringStarted = true;
                    Debug.Log("Stirring started");
                }
            }
            else if(StirringRod._isHoldingStirrRod && !bothPowderTransferredSuccess)
            {
                Debug.Log("Transfer all the powder first.");
            }
            else
            {
                PauseCountdown();
                Debug.Log("Hold the glass rod and mix the iodine and aluminum powder.");
            }
        }
    }

    public void Timer()
    {
        // Check if the countdown is active and not paused
        if (isCountingDown && !isPaused)
        {
            // Update the current time based on the elapsed time since the last frame
            currentTimer -= Time.deltaTime;

            // Check if the countdown has reached zero
            if (currentTimer <= 0f)
            {
                currentTimer = 0f; // Ensure the current time is not negative   
                // Debug.Log("Countdown finished!");
                // Optionally, you can perform some action here when the countdown finishes
                isCountingDown = false; // Stop the countdown
            }

            // Display the current time (rounded to 2 decimal places) in the console
            // Debug.Log("Mixing time left: " + currentTimer.ToString("F2"));
        }
    }

    public void StartCountdown()
    {
        // Start the countdown
        isCountingDown = true;
        isPaused = false; // Ensure the countdown is not paused
    }

    public void StopCountdown()
    {
        // Stop the countdown
        isCountingDown = false;
        isPaused = false; // Ensure the countdown is not paused
    }

    public void PauseCountdown()
    {
        // Pause the countdown
        isPaused = true;
    }

    public void ResumeCountdown()
    {
        // Resume the countdown
        isPaused = false;
    }

    private void MixingProcess()
    {
        // Debug.Log("Transfer success: " + bothPowderTransferredSuccess);
        // Debug.Log("Iodine is success: " + mixingBeakerContent.iodineTransferSuccess);
        // Debug.Log("Aluminum is success: " + mixingBeakerContent.aluminumTransferSuccess);

        // Check if the powders are properly transfered
        if(bothPowderTransferredSuccess)
        {
            if(currentTimer <= 9 && currentTimer >= 8.3f && !alumAlreadyTurnOff)
            {
                alumAlreadyTurnOff = true;
                mBeakerAlumCont.SetActive(false); // Turn off the aluminum
                mixingBeakerContent.iodineValue = 0.4f;  // Add the height of iodine to simulate chnanges is particles
                _mixingBeakerContent.FillBeaker(mixingBeakerContent.iodineValue, _mixingBeakerContent.mixingBeakerContentObj, true);
                // Debug.Log("Iodine content in mixing beaker is: " + mixingBeakerContent.iodineValue); 
                Debug.Log("Aluminum powder should be turn off now."); 
                EnableDisablePhases(0); //1st phase
            }
            else if(currentTimer <= 8 && currentTimer >= 6 && !_1stPhaseDone)
            {
                // 1st texture
                _1stPhaseDone = true;
                // ChangeMaterialofPowder(_1stPhaseMat);
                Debug.Log("Keep mixing mixing the Iodine and Aluminum powder.");
                EnableDisablePhases(1); //2nd phase
            }
            else if(currentTimer <= 5.7 && currentTimer >= 1 && !_2ndPhaseDone)
            {
                // 2nd texture
                _2ndPhaseDone = true;
                // ChangeMaterialofPowder(_2ndPhaseMat);
                Debug.Log("Almost done.");
                EnableDisablePhases(2); //3rd phase
            }
            else if(currentTimer <= 0 && !isMixingDone)
            {
                // Finish
                isMixingDone = true;
                GameMngr.S2currentsteps = 3;
                vrRobot.currentStepExecuted2 = false;
                StopCountdown();
                Debug.Log("Mixing is done.");
                EnableDisablePhases(3); //4th phase
            }
        }
    }

    private void FollowObject2(Transform ObjectToFollow, Transform Follower)
    {
        // Declare targetPosition outside the if-else block
        Vector3 targetPosition;

        // Calculate the angle between ObjectToFollow's down vector and transform's forward vector
        float angle = Vector3.Angle(Vector3.down, transform.forward);

        if (angle <= angleThreshold2 && mixingBeakerContent.iodineValue < 0.26f)
        {
            // Set targetPosition to ObjectToFollow's position without any offset
            targetPosition = new Vector3(ObjectToFollow.position.x, ObjectToFollow.position.y, ObjectToFollow.position.z);
        }
        else
        {
            // Set targetPosition to ObjectToFollow's position with an offset in the y component
            targetPosition = new Vector3(ObjectToFollow.position.x, ObjectToFollow.position.y - 0.0747f, ObjectToFollow.position.z);
        }

        // Set the Follower's position to the new targetPosition
        Follower.position = targetPosition;
    }
    
    private void EnableDisablePhases(int ToEnableObj)
    {
        _PhasesObj[ToEnableObj].SetActive(true);
        // disable other lab materials
        for(int i = 0; i < _PhasesObj.Length; i++) {
            if (i != ToEnableObj) // Skip the object that will be enable
            {
                _PhasesObj[i].SetActive(false);
            }
        }
    }
    
    private void CheckTransferState()
    {
        if(mixingBeakerContent.iodineTransferSuccess && mixingBeakerContent.aluminumTransferSuccess && !activatedTransferState)
        {
            activatedTransferState = true;
            bothPowderTransferredSuccess = true;
        }
    }
}
