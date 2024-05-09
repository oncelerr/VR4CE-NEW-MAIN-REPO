using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class s4Zinc : MonoBehaviour
{
    [SerializeField] Timer _Timer;
    [SerializeField] GameObject ZincObj1;
    [SerializeField] GameObject ZincObj2;
    [SerializeField] GameObject ZincObj3;
    [SerializeField] ParticleSystem Bubbles;
    [SerializeField] ParticleSystem HydrogenBubbles;
    [SerializeField] ParticleSystem BubbleCoat1;
    [SerializeField] ParticleSystem BubbleCoat2;
    [SerializeField] ParticleSystem BubbleCoat3;

    private bool alreadyPlayedBubbles;
    private bool alreadyPlayedHydroBubbles;
    private bool timerStartedForCoating;
    public static int WhichZinc = 0;
    public static bool ZincCoatFX1;
    public static bool ZincCoatFX2;
    public static bool ZincCoatFX3;
    public static bool ZincBubblesFX1;
    public static bool ZincBubblesFX2;
    public static bool ZincBubblesFX3;
    public static bool Zinc1isChosen;
    public static bool Zinc2isChosen;
    public static bool Zinc3isChosen;   

    private void Start() 
    {
        alreadyPlayedBubbles = false;
        alreadyPlayedHydroBubbles = false;
        Zinc1isChosen = false;
        Zinc2isChosen = false;
        Zinc3isChosen = false;
        ZincCoatFX1 = false;
        ZincCoatFX2 = false;
        ZincCoatFX3 = false;
        ZincBubblesFX1 = false;
        ZincBubblesFX2 = false;
        ZincBubblesFX3 = false;
        
    }
    private void Update()
    {
        if(WhichZinc == 1 && Zinc1isChosen) // zinc 1
        {
            // Which effects
            if(ZincCoatFX1)
            {
                ChemCoated(ZincObj1);
            }
            if(ZincBubblesFX1)
            {
                BubbleCoated();
            }
        }
        if(WhichZinc == 2 && Zinc2isChosen) // zinc 2
        {
            // Which effects
            if(ZincCoatFX2)
            {
                ChemCoated(ZincObj2);
            }
            if(ZincBubblesFX2)
            {
                BubbleCoated();
            }
        }
        if(WhichZinc == 3 && Zinc3isChosen) // zinc 3
        {
            // Which effects
            if(ZincCoatFX3)
            {
                ChemCoated(ZincObj3);
            }
            if(ZincBubblesFX3)
            {
                BubbleCoated();
            }
        }
        
        BubbleCoated();
        HydrogenGasFX();
    }

    private void BubbleCoated()
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // Checks if the copper sulfate liquide already transfered
            if(s4TestTube4._s4Tube4Amount >= 0.8f && !alreadyPlayedBubbles)
            {
                alreadyPlayedBubbles = true;
                Sequence sequence = DOTween.Sequence();
                sequence.AppendCallback(() => Bubbles.Play()); // Play bubbles 
                sequence.OnComplete(() => { 
                        // 
                        if(WhichZinc == 1)
                        {
                            BubbleCoat1.Play();
                        }
                        if(WhichZinc == 2)
                        {
                            BubbleCoat2.Play();
                        }
                        if(WhichZinc == 3)
                        {
                            BubbleCoat3.Play();
                        }
                    });
                sequence.Play();
            }
        }
    }

    private void HydrogenGasFX()
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // Checks if the copper sulfate liquide already transfered
            if(s4TestTube6._s4Tube6Amount >= 0.8f && !alreadyPlayedHydroBubbles)
            {
                alreadyPlayedHydroBubbles = true;
                HydrogenBubbles.Play();
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
                CoatIntensity = Timer.CUcurrentTime3 * 0.05f;

                // Set the fill value in the material
                material.SetFloat("_Snow_Intensity", CoatIntensity);

                // Checks if the copper liquid is already transfered
                if(s4TestTube4._s4Tube4Amount >= 0.8f && !timerStartedForCoating)
                {
                    timerStartedForCoating = true;
                    _Timer.StartCountUpTimer3(0f, 20f); // Start timer
                }
            }
        }
    }
    
    public void WhichZincPick(int metal)
    {
        if(metal == 1 && !Zinc1isChosen)
        {
            WhichZinc = metal;
            Debug.Log("Player chosed "+WhichZinc);
        }
        if(metal == 2 && !Zinc2isChosen)
        {
            WhichZinc = metal;
            Debug.Log("Player chosed "+WhichZinc);
        }
        if(metal == 3 && !Zinc3isChosen)
        {
            WhichZinc = metal;
            Debug.Log("Player chosed "+WhichZinc);
        }        
    }
}
