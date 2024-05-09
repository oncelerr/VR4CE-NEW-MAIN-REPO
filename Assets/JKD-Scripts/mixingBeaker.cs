using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixingBeaker : MonoBehaviour
{
    // Scripts
    [SerializeField] mixingBeakerContent _mixingBeakerContent;
    [SerializeField] AudioMngr _AudioMngr;


    // Particle FX
    public ParticleSystem SmokeWhite;
    public ParticleSystem SmokeBlack;
    public ParticleSystem SmokeBlackPurple;
    public ParticleSystem SmokeOrangePurpleWhite;
    public ParticleSystem S2Fire;
    private float S2FireStartLiftime = 1.94f;
    private float S2FireFinalLiftime = 0f;
    public GameObject mBeakerBlackCont;
    public GameObject mBeakerIodineContFP;


    // Timer Variables
    public float Endtime;
    private float ReactionTime;
    private bool isCountingDown = false; 
    private bool isPaused = false; 
    private bool alreadyGetDropWater;
    private bool alreadyDroppedWater;

    // Follow empty beaker reference
    public Transform mixingBeakerT;
    public Transform mixingBeakerPourAreaT;
    public float angleThreshold;

    // Holding state variables
    public static bool isItHoldingIodineBeaker;
    public static bool isItHoldingAluminumBeaker;
    
    // Phases variables
    private bool ChemReactStarted;
    private bool Phase1Done;
    private bool Phase2Done;
    private bool Phase3Done;
    private bool Phase4Done;
    private bool Phase5Done;
    private bool Phase6Done;
    private bool Phase7Done;
    private bool Phase8Done;

    private void Start()
    {
        // Initalise variables
        ChemReactStarted = false;
        Phase1Done = false;
        Phase2Done = false;
        Phase3Done = false;
        Phase4Done = false;
        Phase5Done = false;
        Phase6Done = false;
        Phase7Done = false;
    }
    
    private void Update() 
    {
        FollowObject(mixingBeakerT, mixingBeakerPourAreaT);
        CheckChemReact();
    }
    
    public void HoldingIodineBeaker(bool IodineBeaker)
    {
        if(IodineBeaker)
        {
            isItHoldingIodineBeaker = true;
        }
        else 
        {
            isItHoldingIodineBeaker = false;
        }
    }

    public void HoldingAluminumBeaker(bool AluminumBeaker)
    {
        if(AluminumBeaker)
        {
            isItHoldingAluminumBeaker = true;
        }
        else 
        {
            isItHoldingAluminumBeaker = false;
        }
    }

    private void FollowObject(Transform ObjectToFollow, Transform Follower)
    {
        // Declare targetPosition outside the if-else block
        Vector3 targetPosition;

        // Calculate the angle between ObjectToFollow's down vector and transform's forward vector
        float angle = Vector3.Angle(Vector3.down, transform.forward);

        if (angle <= angleThreshold && mixingBeakerContent.iodineValue < 0.26f)
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
    
    private void CheckChemReact()
    {
        // Check if already put some drops of water in the mixture
        // if(mixingBeakerDipArea.pippetteWaterDrop && !ChemReactStarted)
        if(mixingBeakerDipArea.pippetteWaterDrop)
        {
            // ChemReactStarted = true;
            // Start time reaction
            Timer("Start");
            S2ChemReactSequence();
        }
    }

    private void Timer(string State)
    {
        // Check if the countdown is active and not paused
        if (isCountingDown && !isPaused)
        {
            // Update the current time based on the elapsed time since the last frame
            ReactionTime += Time.deltaTime;

            // Check if the countdown has reached 60 seconds
            if (ReactionTime >= Endtime)
            {
                // ReactionTime = 60f; // Ensure the current time does not exceed 60 seconds
                // Debug.Log("Time's up!"); // Indicate that the time is up
                isCountingDown = false; // Stop the countdown
            }

            // Display the current time (rounded to 2 decimal places) in the console
            // Debug.Log("Time elapsed: " + ReactionTime.ToString("F2"));
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

    private void S2ChemReactSequence()
    {
        if(GameMngr.CurrentLevelIndex == 2)
        {
            if(ReactionTime >= 0f && ReactionTime <=5f && !Phase1Done) // 1st Phase
            {
                // Delay 5s
                Phase1Done = true;
                Debug.Log("Iodine and Aluminum reaction started");
            }
            else if(ReactionTime >= 5.1f && ReactionTime <=10f && !Phase2Done) // 2nd Phase
            {
                Phase2Done = true;
                // White smoke
                SmokeWhite.Play();
                // Safely stop other fx
                SmokeBlack.Stop();
                SmokeBlackPurple.Stop();
                SmokeOrangePurpleWhite.Stop();
                S2Fire.Stop();
                Debug.Log("White smoke started");
                _AudioMngr.PlayVRBotS2Reactions(_AudioMngr.vrBotReactions[0]);  // hmm look at that smoke
            }
            else if(ReactionTime >= 10.1f && ReactionTime <=14f && !Phase3Done) // 3rd Phase
            {
                Phase3Done = true;
                // Turn off final phase object and activate black content
                mBeakerIodineContFP.SetActive(false);
                mBeakerBlackCont.SetActive(true);
                // Black smoke
                SmokeBlack.Play();
                // Stop other fx
                SmokeWhite.Stop();
                SmokeBlackPurple.Stop();
                SmokeOrangePurpleWhite.Stop();
                S2Fire.Stop();
                Debug.Log("Black smoke started");
            }
            else if(ReactionTime >= 14.1f && ReactionTime <=18f && !Phase4Done) // 4th Phase
            {
                Phase4Done = true;
                // Black and Purple smoke
                SmokeBlackPurple.Play();
                // Stop other fx
                SmokeBlack.Stop();
                SmokeWhite.Stop();
                SmokeOrangePurpleWhite.Stop();
                S2Fire.Stop();
                Debug.Log("Black and purple smoke started");
                _AudioMngr.PlayVRBotS2Reactions(_AudioMngr.vrBotReactions[1]);  // woah look at that purple smoke
            }
            else if(ReactionTime >= 18.1f && ReactionTime <=25f && !Phase5Done) // 5th Phase
            {
                Phase5Done = true;
                // White, Purple and Orange smoke
                SmokeOrangePurpleWhite.Play();
                // Stop other fx
                SmokeBlackPurple.Stop();
                SmokeBlack.Stop();
                SmokeWhite.Stop();
                S2Fire.Stop();
                Debug.Log("White, orange and purple smoke started");
            }
            else if(ReactionTime >= 25.1f && ReactionTime <=50f && !Phase6Done) // 6th Phase
            {
                Phase6Done = true;
                // Purple smoke and fire
                S2Fire.Play();
                // Stop other fx
                SmokeOrangePurpleWhite.Stop();
                SmokeBlackPurple.Stop();
                SmokeBlack.Stop();
                SmokeWhite.Stop();
                // Decrease amount of black content
                _mixingBeakerContent.FillBeaker(0.25f, mBeakerBlackCont, true);
                Debug.Log("Purple smoke and fire started");
                _AudioMngr.PlayVRBotS2Reactions(_AudioMngr.vrBotReactions[2]);  // wow isn`t it beautiful?
            }
            
            else if(ReactionTime >= 50.1f && ReactionTime <=59f && !Phase7Done) // 7th Phase, decrease the lifetime
            {
                Phase7Done = true;
                // Purple smoke and fire started to decrease lifetime
                S2Fire.Play();

                // Get the current main module of the particle system
                var mainModule = S2Fire.main;

                // Decrease the start lifetime by the specified amount
                mainModule.startLifetime = Mathf.Max(mainModule.startLifetime.constant - 1.41f, 0f);
                Debug.Log("Purple smoke and fire started  to decrease lifetime");
            }
            
            else if(ReactionTime >= 60f && !Phase8Done) // 8th Phase
            {
                Phase8Done = true;
                // Stop all fx
                S2Fire.Stop();
                SmokeOrangePurpleWhite.Stop();
                SmokeBlackPurple.Stop();
                SmokeBlack.Stop();
                SmokeWhite.Stop();
                Debug.Log("All particle fx stopped");
                GameMngr.S2currentsteps = 6;
                vrRobot.currentStepExecuted2 = false;
            }
        }
    }
}
