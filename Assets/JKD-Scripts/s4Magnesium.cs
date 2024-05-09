using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class s4Magnesium : MonoBehaviour
{
    [SerializeField] Timer _Timer;
    [SerializeField] GameObject MagnesiumObj1;
    [SerializeField] GameObject MagnesiumObj2;
    [SerializeField] ParticleSystem MgParticlesUP;
    [SerializeField] ParticleSystem MgParticlesDOWN;
    private bool alreadyPlayedMgParticlesUP;
    private bool timerStartedForMGtoDissolve;
    public static int WhichMagnesium = 1;
    public static bool Magnesium1;
    public static bool Magnesium2;
    public static bool DissolveFX;

    private void Start() 
    {
        alreadyPlayedMgParticlesUP = false;
        Magnesium1 = false;
        Magnesium2 = false;
        DissolveFX = false;
    }
    private void Update() 
    {
        ParticleDebris();
    
        if(WhichMagnesium == 1 && Magnesium1) // Magnesium 1
        {
            // effects
            if(DissolveFX)
            {
                DissolveMagnesium(MagnesiumObj1);
            }
        }
        if(WhichMagnesium == 2 && Magnesium2) // Magnesium 2
        {
            // effects
            if(DissolveFX)
            {
                DissolveMagnesium(MagnesiumObj2);
            }
        }
    }

    private void ParticleDebris()
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // Checks if the copper sulfate liquide already transfered
            if(s4TestTube1._s4Tube1Amount >= 0.8f && !alreadyPlayedMgParticlesUP)
            {
                alreadyPlayedMgParticlesUP = true;
                Sequence sequence = DOTween.Sequence();
                sequence.AppendCallback(() => MgParticlesUP.Play()); // Play the debris particles going up
                sequence.AppendInterval(20f); // Delay
                sequence.AppendCallback(() => MgParticlesDOWN.Play()); // Play the debris particles going down
                sequence.Play();
            }
        }
    }

    private void DissolveMagnesium(GameObject MetalChem) 
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // Get the Renderer component of the GameObject
            Renderer tubeRenderer = MetalChem.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = tubeRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Dissolve"))
            {
                // Get the current fill value from the material
                float DissolveValue = material.GetFloat("_Dissolve");
                // Clamp the fill value to stay within the range 0 to 1
                DissolveValue = Mathf.Clamp01(DissolveValue);
                
                // Multiply time with 0.1f for transition
                DissolveValue = Timer.CUcurrentTime * 0.025f;

                // Set the fill value in the material
                material.SetFloat("_Dissolve", DissolveValue);

                // Checks if the copper liquid is already transfered
                if(s4TestTube1._s4Tube1Amount >= 0.8f && !timerStartedForMGtoDissolve)
                {
                    timerStartedForMGtoDissolve = true;
                    _Timer.StartCountUpTimer(0f, 20f); // Start timer
                }
            }
        }
    }

    public void WhichMagnesiumPick(int metal)
    {
        if(metal == 1 && !Magnesium1)
        {
            WhichMagnesium = metal;
            Debug.Log("Player selected magnesium "+WhichMagnesium);
        }
        if(metal == 2 && !Magnesium2)
        {
            WhichMagnesium = metal;
            Debug.Log("Player selected magnesium "+WhichMagnesium);
        }
    }
}
