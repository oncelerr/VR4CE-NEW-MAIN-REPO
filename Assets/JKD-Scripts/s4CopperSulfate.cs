using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s4CopperSulfate : MonoBehaviour
{
    ParticleSystem _CopperSulfatePour;
    private Material material;
    public GameObject _CopperSulfateCont;
    private bool success = false;
    private bool wasted = false;
    public static float _CopperSulfateAmount = 0.4f;


    void Start()
    {
        _CopperSulfatePour = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        float angle = Vector3.Angle(Vector3.down, transform.forward);
        if (angle <= 70f && s4TestTube1._s4Tube1Amount < 0.8f)
        {
            _CopperSulfatePour.Play();
        }
        else
        {
            _CopperSulfatePour.Stop();
        }
        UpdateCopperSulfateContent();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("tube1"))
        {
            if(s4TestTube1._s4Tube1Amount < 0.8f && s4TestTube1._s4SubStep1 == 1)
            {
                // will increment the fill value of the container
                s4TestTube1._s4Tube1Amount += 0.01f;
                _CopperSulfateAmount -= 0.01f;
            }
        }
        // else if(_CopperSulfateAmount > 0) // This check if the player spilled the liquid
        // {
        //     _CopperSulfateAmount -= 0.01f;
        // }
    }

    private void UpdateCopperSulfateContent()
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // This checks if liquid was spilled
            if(_CopperSulfateAmount <= 0f)
            {
                // Stop the particles pouring
                // _CopperSulfatePour.Stop();

                Invoke("CheckTransferCopperSulfate",1f);
            }
            // Get the Renderer component of the GameObject
            Renderer ChemRenderer = _CopperSulfateCont.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = ChemRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");

                // Equate to static variable na connected sa test tube
                fillValue = _CopperSulfateAmount;

                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);

                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);
            }
        }
    }

    private void CheckTransferCopperSulfate()
    {
        if(s4TestTube1._s4Tube1Amount >= 0.8f && !success) 
        {
            // Transfer Success
            success = true;
            if(GameMngr.S4currentsteps == 1)
            {
                GameMngr.S4currentsteps = 2;
                vrRobot.currentStepExecuted4 = false;
            }
            
            Debug.Log("Copper sulfate transfer success.");
        }
        // else if(s4TestTube1._s4Tube1Amount < 0.6f && !wasted)
        // {
        //     // Copper Sulfate liquid wasted
        //     wasted = true;
        //     Debug.Log("Copper sulfate spilled.");
        //     // GameMngr.S2SpilledChemPowder = true; // trigger if the player spilled a powder
        // }
    }
}
