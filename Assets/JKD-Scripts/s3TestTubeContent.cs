using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class s3TestTubeContent : MonoBehaviour
{
    public AudioMngr _AudioMngr;
    public Timer _Timer;
    public GameObject[] testtubeObj;
    public static float s3testtubeAmount;
    private bool success;
    private bool step1Triggered;
    public static int whichtestubeisHolding = 0; // variable for checking if the player holds the tube
    public static bool testtubeHoldingByHuman;
    // Ferrous sulfate transfer success variables
    public static bool FerrousTransferSuccess;

    // Ferrous sulfate content transition
    private bool s3React1Done = false;
    private bool s3React2Done = false;
    private bool s3React3Done = false;
    private int S3ChemTransition = 1;


    private void OnEnable()
    {
        // Initialize variables
        step1Triggered = false;
        success = false;
        s3testtubeAmount = 0f;
        whichtestubeisHolding = 0;
    }

    private void Update()
    {
        CheckFerrousTransferStatus();
        // Debug.Log("Test tube chosen is: "+whichtestubeisHolding);
        if (success)
        {
            UpdateFerrousContent(testtubeObj[s3TestTubeHolder.testtubeholderIndex]);
        }
        else
        {
            UpdateFerrousContent(testtubeObj[whichtestubeisHolding]);
        }
    }

    private void UpdateFerrousContent(GameObject tube)
    {
        if (GameMngr.CurrentLevelIndex == 3)
        {

            // Debug.Log("Iodine in the IB: " +s3testtubeAmount);
            // Debug.Log("Iodine in the EB: " +mixingBeakerContent.iodineValue);

            // Get the Renderer component of the GameObject
            Renderer tubeRenderer = tube.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = tubeRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill") && material.HasProperty("_Transition1") && material.HasProperty("_Transition2"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");
                // Equate to static variable na connected sa beaker
                fillValue = s3testtubeAmount;
                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);
                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);
                // Debug.Log("Iodine Current Fill Value: " + fillValue);


                // Update the color of the ferrous sulfate
                // Get the transition property from the material(shader)
                float transition1 = material.GetFloat("_Transition1");
                float transition2 = material.GetFloat("_Transition2");
                // Multiply timer with 0.01 to get smooth transition
                transition1 = Timer.CUcurrentTime * 0.1f;
                transition2 = Timer.CUcurrentTime * 0.1f;

                // This change to transition 1
                if (Timer.CUcurrentTime < 11f && S3ChemTransition == 1) //Transition 1
                {
                    // Set the fill value in the material
                    material.SetFloat("_Transition1", transition1);
                }

                // This change to transition 2
                if (Timer.CUcurrentTime < 11f && S3ChemTransition == 2) //Transition 2
                {
                    // Set the fill value in the material
                    material.SetFloat("_Transition2", transition2);
                }

                // PLay vrBot`s voice over for transition 1
                if (Timer.CUcurrentTime == 2 && !s3React1Done)  //Transition 1
                {
                    _AudioMngr.PlayVRBotChemReactions(_AudioMngr.vrBotReactions3[0]);
                    Debug.Log("S3 React1 done");
                }

                // Reset the timer to 0
                if (Timer.CUcurrentTime == 10 && !s3React1Done)
                {
                    s3React1Done = true;
                    Timer.CUcurrentTime = 0;
                    S3ChemTransition = 2;
                    _Timer.StartCountUpTimer(0f, 10f);
                }

                // PLay vrBot`s voice over for transition 2
                if (Timer.CUcurrentTime == 2 && s3React1Done && !s3React2Done)  //Transition 2
                {
                    s3React2Done = true;
                    Sequence sequence = DOTween.Sequence();
                    sequence.AppendCallback(() => _AudioMngr.PlayVRBotChemReactions(_AudioMngr.vrBotReactions3[1])); // r1   
                    sequence.AppendInterval(_AudioMngr.vrBotReactions3[1].length); // Delay
                    sequence.OnComplete(() => {
                        // Play vrBot`s final voice over 
                        GameMngr.S3currentsteps = 6f;
                        vrRobot.currentStepExecuted3 = false;
                    });
                    sequence.Play();
                    Debug.Log("S3 React2 done");
                }
            }
        }
    }

    public void WhichTestTube(int tube)
    {
        if (testtubeHoldingByHuman)
        {
            if (tube == 1)
            {
                whichtestubeisHolding = tube;
                s3TestTubeHolder.testtubeholderIndex = tube;
                if (!step1Triggered)
                {
                    step1Triggered = true;
                    GameMngr.S3currentsteps = 1;
                    vrRobot.currentStepExecuted3 = false;
                }
                Debug.Log("Player chose test tube " + whichtestubeisHolding);
            }
            if (tube == 2)
            {
                whichtestubeisHolding = tube;
                s3TestTubeHolder.testtubeholderIndex = tube;
                if (!step1Triggered)
                {
                    step1Triggered = true;
                    GameMngr.S3currentsteps = 1;
                    vrRobot.currentStepExecuted3 = false;
                }
                Debug.Log("Player chose test tube " + whichtestubeisHolding);
            }
            if (tube == 3)
            {
                whichtestubeisHolding = tube;
                s3TestTubeHolder.testtubeholderIndex = tube;
                if (!step1Triggered)
                {
                    step1Triggered = true;
                    GameMngr.S3currentsteps = 1;
                    vrRobot.currentStepExecuted3 = false;
                }
                Debug.Log("Player chose test tube " + whichtestubeisHolding);
            }
            if (tube == 4)
            {
                whichtestubeisHolding = tube;
                s3TestTubeHolder.testtubeholderIndex = tube;
                if (!step1Triggered)
                {
                    step1Triggered = true;
                    GameMngr.S3currentsteps = 1;
                    vrRobot.currentStepExecuted3 = false;
                }
                Debug.Log("Player chose test tube " + whichtestubeisHolding);
            }
        }
        else
        {
            whichtestubeisHolding = 0;
        }


    }

    private void CheckFerrousTransferStatus()  //THis checks if the ferrous liquid is transfered succesfully
    {
        if (s3testtubeAmount >= 0.5f && !success)
        {
            success = true;
            FerrousTransferSuccess = true;
            GameMngr.S3currentsteps = 2;
            vrRobot.currentStepExecuted3 = false;
            s3TestTubeHolder.testtubeholderIndex = whichtestubeisHolding;
            Debug.Log("Ferrous sulfate transfer success!");
        }
    }
}
