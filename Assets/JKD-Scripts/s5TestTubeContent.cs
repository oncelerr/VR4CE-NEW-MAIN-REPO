using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class s5TestTubeContent : MonoBehaviour
{
    public AudioMngr _AudioMngr;
    public Timer _Timer;
    public GameObject[] testtubeObj;
    public GameObject[] testtubePCCont;
    public static float s5testtubeAmount;
    public static float s5testtubeAmountPC;
    private bool success;
    private bool success2;
    private bool step1Triggered;
    public static int S5whichtestubeisHolding = 0; // variable for checking if the player holds the tube
    public static bool S5testtubeHoldingByHuman;
    // Ferrous sulfate transfer success variables
    public static bool SilverNitrateTransferSuccess;
    public static bool PotassiumCarbonateTransferSuccess;

    // Ferrous sulfate content transition
    private bool s3React1Done = false;
    private bool s3React2Done = false;
    private bool s3React3Done = false;
    private bool s5React1Done = false;
    private bool s5React2Done = false;
    private bool s5React3Done = false;
    private int S3ChemTransition = 1;


    private void OnEnable() 
    {
        // Initialize variables
        step1Triggered = false;
        success = false;
        success2 = false;
        s5testtubeAmount = 0f;
        s5testtubeAmountPC = 0f;
        S5whichtestubeisHolding = 0;
    }
    
    private void Update()
    {
        CheckSilverNitrateTransferStatus();
        CheckPotassiumCarbonateTransferStatus();
        // Debug.Log("Test tube chosen is: "+S5whichtestubeisHolding);
        if(success)
        {
            UpdateSilverNitrateContent(testtubeObj[s5TestTubeHolder.S5testtubeholderIndex]);
        }
        else
        {
            UpdateSilverNitrateContent(testtubeObj[S5whichtestubeisHolding]);
        }
        if(success2)
        {
            UpdatePotassiumCarbonateContent(testtubePCCont[s5TestTubeHolder.testtubeholderIndexPC]);
        }
        else
        {
            UpdatePotassiumCarbonateContent(testtubePCCont[S5whichtestubeisHolding]);
        }
    }
 
    private void UpdateSilverNitrateContent(GameObject tube) 
    {
        if(GameMngr.CurrentLevelIndex == 5)
        {
            // Debug.Log("Iodine in the IB: " +s5testtubeAmount);
            // Debug.Log("Iodine in the EB: " +mixingBeakerContent.iodineValue);
            
            // Get the Renderer component of the GameObject
            Renderer tubeRenderer = tube.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = tubeRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");
                // Equate to static variable na connected sa beaker
                fillValue = s5testtubeAmount;
                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);
                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);
                // Debug.Log("Iodine Current Fill Value: " + fillValue);


                // Update the color of the ferrous sulfate
                // Get the transition property from the material(shader)
                float SN_Opacity = material.GetFloat("_Opacity");
                // Multiply timer with 0.01 to get smooth transition
                SN_Opacity = Timer.CUcurrentTime * 0.1f;
                
                if(success2)
                {
                    // Set the opacity value in the material
                    material.SetFloat("_Opacity", SN_Opacity);
                }

                if(Timer.CUcurrentTime == 4 && !s5React3Done)
                {
                    s5React3Done = true;
                    Sequence sequence = DOTween.Sequence();
                    sequence.AppendCallback(() => _AudioMngr.PlayVRBotChemReactions(_AudioMngr.vrBotReactions5[0])); // r1   
                    sequence.AppendInterval(_AudioMngr.vrBotReactions5[0].length); // Delay
                    sequence.AppendCallback(() => _AudioMngr.PlayVRBotChemReactions(_AudioMngr.vrBotReactions5[1])); // r1   
                    sequence.AppendInterval(_AudioMngr.vrBotReactions5[1].length); // Delay
                    sequence.OnComplete(() => { 
                            s5React2Done = true;
                            // Play vrBot`s final voice over 
                            GameMngr.S5currentsteps = 5f;
                            vrRobot.currentStepExecuted5 = false;
                        });
                    sequence.Play();
                }
            }
        }
    }

    private void UpdatePotassiumCarbonateContent(GameObject tube) 
    {
        if(GameMngr.CurrentLevelIndex == 5)
        {
            // Get the Renderer component of the GameObject
            Renderer tubeRenderer = tube.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = tubeRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");
                // Equate to static variable na connected sa beaker
                fillValue = s5testtubeAmountPC;
                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);
                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);

                // Update the opacity of potassium carbonate
                // Get the transition property from the material(shader)
                float PC_Opacity = material.GetFloat("_Opacity");

                if(!s5React2Done)
                {
                    // Multiply timer with 0.1 to get smooth transition
                    PC_Opacity = Timer.LoopCount * 0.1f;
                }
                
                if(!s5React1Done && s5React2Done)
                {
                    s5React1Done = true;
                    Timer.isRunningLoop = false;  //Off the looping
                    PC_Opacity = 0.7f;
                }

                // Set the opacity value in the material
                material.SetFloat("_Opacity", PC_Opacity);
            }
        }
    }

    public void WhichTestTube(int tube)
    {
        if(S5testtubeHoldingByHuman)
        {
            DOTween.Pause("p13"); // Pause scripts 1-7 if player is already ppe ready
            if(tube == 1) 
            {
                S5whichtestubeisHolding = tube;
                s5TestTubeHolder.S5testtubeholderIndex = tube;
                if(!step1Triggered)
                {   
                    step1Triggered = true;
                    GameMngr.S5currentsteps = 1;
                    vrRobot.currentStepExecuted5 = false;
                }
                Debug.Log("Player chose test tube "+S5whichtestubeisHolding);
            }
            if(tube == 2) 
            {
                S5whichtestubeisHolding = tube;
                s5TestTubeHolder.S5testtubeholderIndex = tube;
                if(!step1Triggered)
                {   
                    step1Triggered = true;
                    GameMngr.S5currentsteps = 1;
                    vrRobot.currentStepExecuted5 = false;
                }
                Debug.Log("Player chose test tube "+S5whichtestubeisHolding);
            }
            if(tube == 3) 
            {
                S5whichtestubeisHolding = tube;
                s5TestTubeHolder.S5testtubeholderIndex = tube;
                if(!step1Triggered)
                {   
                    step1Triggered = true;
                    GameMngr.S5currentsteps = 1;
                    vrRobot.currentStepExecuted5 = false;
                }
                Debug.Log("Player chose test tube "+S5whichtestubeisHolding);
            }
            if(tube == 4) 
            {
                S5whichtestubeisHolding = tube;
                s5TestTubeHolder.S5testtubeholderIndex = tube;
                if(!step1Triggered)
                {   
                    step1Triggered = true;
                    GameMngr.S5currentsteps = 1;
                    vrRobot.currentStepExecuted5 = false;
                }
                Debug.Log("Player chose test tube "+S5whichtestubeisHolding);
            }
        }
        else
        {
            S5whichtestubeisHolding = 0;
        }
    }

    private void CheckSilverNitrateTransferStatus()  //THis checks if silver nitrate liquid is transfered succesfully
    {
        if(s5testtubeAmount >= 0.5f && GameMngr.S5currentsteps == 2 && !success)
        {
            success = true;
            SilverNitrateTransferSuccess = true;
            GameMngr.S5currentsteps = 3;
            vrRobot.currentStepExecuted5 = false;
            s5TestTubeHolder.S5testtubeholderIndex = S5whichtestubeisHolding;
            Debug.Log("Silver nitrate transfer success!");
        }
    }

    private void CheckPotassiumCarbonateTransferStatus()  //THis checks if potassium carbonate liquid is transfered succesfully
    {
        if(s5testtubeAmountPC >= 0.8f && GameMngr.S5currentsteps == 3 && !success2)
        {
            success2 = true;
            PotassiumCarbonateTransferSuccess = true;
            GameMngr.S5currentsteps = 4;
            vrRobot.currentStepExecuted5 = false;
            Timer.isRunningLoop = true;
            _Timer.StartCountUpTimer(0f, 10f);
            s5TestTubeHolder.testtubeholderIndexPC = S5whichtestubeisHolding;
            Debug.Log("Potassium Carbonate transfer success!");
        }
    }
}
