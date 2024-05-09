using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s4SilverNitrate : MonoBehaviour
{
    ParticleSystem _SilverNitratePour;
    private Material material;
    public GameObject _SilverNitrateCont;
    private bool success = false;
    private bool wasted = false;    
    public static float _SilverNitrateAmount = 0.4f;


    void Start()
    {
        _SilverNitratePour = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        float angle = Vector3.Angle(Vector3.down, transform.forward);
        if (angle <= 70f && s4TestTube2._s4Tube2Amount < 0.8f)
        {
            _SilverNitratePour.Play();
        }
        else
        {
            _SilverNitratePour.Stop();
        }
        UpdateCopperSulfateContent();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("tube2"))
        {
            if(s4TestTube2._s4Tube2Amount < 0.8f && s4TestTube2._s4SubStep2 == 1)
            {
                // will increment the fill value of the container
                s4TestTube2._s4Tube2Amount += 0.01f;
                _SilverNitrateAmount -= 0.01f;
            }
        }
        // else if(_SilverNitrateAmount > 0) // This check if the player spilled the liquid
        // {
        //     _SilverNitrateAmount -= 0.01f;
        // }
    }

    private void UpdateCopperSulfateContent()
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // This checks if liquid was spilled
            if(_SilverNitrateAmount <= 0f)
            {
                // Stop the particles pouring
                // _SilverNitratePour.Stop();

                Invoke("CheckTransferSilverNitrate",1f);
            }
            // Get the Renderer component of the GameObject
            Renderer ChemRenderer = _SilverNitrateCont.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = ChemRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");

                // Equate to static variable na connected sa test tube
                fillValue = _SilverNitrateAmount;

                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);

                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);
            }
        }
    }

    private void CheckTransferSilverNitrate()
    {
        if(s4TestTube2._s4Tube2Amount >= 0.8f && !success) 
        {
            // Transfer Success
            success = true;
            if(GameMngr.S4currentsteps == 2)
            {
                GameMngr.S4currentsteps = 3;
                vrRobot.currentStepExecuted4 = false;
            }
            
            Debug.Log("Silver Nitrate transfer success.");
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
