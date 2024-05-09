using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class s4Copper : MonoBehaviour
{
    [SerializeField] Timer _Timer;
    [SerializeField] GameObject CopperObj1;
    [SerializeField] GameObject CopperObj2;
    [SerializeField] ParticleSystem Bubbles;
    [SerializeField] ParticleSystem BubblesCoat1;
    [SerializeField] ParticleSystem BubblesCoat2;
    private bool alreadyPlayedBubbles;
    private bool timerStartedForCoating;
    public static int WhichCopper = 1;
    public static bool Copper1;
    public static bool Copper2;
    public static bool CopperCoatedFX;


    private void Start() 
    {
        alreadyPlayedBubbles = false;
        Copper1 = false;
        Copper2 = false;
    }
    private void Update() 
    {
        BubbleCoated();
        if(WhichCopper == 1 && Copper1) // copper 1
        {
            // effects
            if(CopperCoatedFX)
            {
                ChemCoated(CopperObj1);
            }
        }
        if(WhichCopper == 2 && Copper2) // copper 2
        {
            // effects
            if(CopperCoatedFX)
            {
                ChemCoated(CopperObj2);
            }
        }
    }

    private void BubbleCoated()
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // Checks if the copper sulfate liquide already transfered
            if(s4TestTube2._s4Tube2Amount >= 0.8f && !alreadyPlayedBubbles)
            {
                alreadyPlayedBubbles = true;
                Sequence sequence = DOTween.Sequence();
                sequence.AppendCallback(() => Bubbles.Play()); // Play bubbles 
                sequence.OnComplete(() => { 
                        if(WhichCopper == 1)
                        {
                            BubblesCoat1.Play();
                        }   
                        else
                        {
                            BubblesCoat2.Play();
                        }
                    });
                sequence.Play();
            }
        }
    }

    private void ChemCoated(GameObject MetalChem) 
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // Get the Renderer component of the GameObject
            Renderer tubeRenderer = MetalChem.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = tubeRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Snow_Intensity"))
            {
                // Get the current fill value from the material
                float CoatIntensity = material.GetFloat("_Snow_Intensity");
                // Clamp the fill value to stay within the range 0 to 1
                CoatIntensity = Mathf.Clamp01(CoatIntensity);
                
                // Multiply time with 0.1f for transition
                CoatIntensity = Timer.CUcurrentTime2 * 0.05f;

                // Set the fill value in the material
                material.SetFloat("_Snow_Intensity", CoatIntensity);

                // Checks if the copper liquid is already transfered
                if(s4TestTube2._s4Tube2Amount >= 0.8f && !timerStartedForCoating)
                {
                    timerStartedForCoating = true;
                    _Timer.StartCountUpTimer2(0f, 20f); // Start timer
                }
            }
        }
    }

    public void WhichCopperPick(int metal)
    {
        if(metal == 1 && !Copper1)
        {
            WhichCopper = metal;
        }
        if(metal == 2 && !Copper2)
        {
            WhichCopper = metal;
        }
    }
}
