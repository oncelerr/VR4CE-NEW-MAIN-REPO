using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s4HydrochloricAcid : MonoBehaviour
{
    ParticleSystem _HydrochloricAcidPour;
    private Material material;
    public GameObject _HydrochloricAcidCont;
    private bool success = false;
    private bool success2 = false;
    private bool wasted = false;    
    public static float _HydrochloricAcidAmount = 0.55f;
    private int whichtesttube = 0;


    void Start()
    {
        _HydrochloricAcidPour = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // Test tube 3
        float angle = Vector3.Angle(Vector3.down, transform.forward);
        if (angle <= 70f && s4TestTube3._s4Tube3Amount < 0.8f)
        {
            _HydrochloricAcidPour.Play();
        }
        else
        {
            _HydrochloricAcidPour.Stop();
        }

        // Test tube 6
        if (angle <= 70f && s4TestTube6._s4Tube6Amount < 0.8f)
        {
            _HydrochloricAcidPour.Play();
        }
        else
        {
            _HydrochloricAcidPour.Stop();
        }

        UpdateCopperSulfateContent();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("tube3"))
        {
            if(s4TestTube3._s4Tube3Amount < 0.8f && s4TestTube3._s4SubStep3 == 1)
            {
                whichtesttube = 3;
                // will increment the fill value of the container
                s4TestTube3._s4Tube3Amount += 0.01f;
                if(_HydrochloricAcidAmount > 0.4f)
                {
                    _HydrochloricAcidAmount -= 0.01f;
                }
            }
        }
        if (other.CompareTag("tube6"))
        {
            if(s4TestTube6._s4Tube6Amount < 0.8f && s4TestTube6._s4SubStep6 == 1)
            {
                whichtesttube = 6;
                // will increment the fill value of the container
                s4TestTube6._s4Tube6Amount += 0.01f;
                _HydrochloricAcidAmount -= 0.01f;
            }
        }
        // else if(_HydrochloricAcidAmount > 0) // This check if the player spilled the liquid
        // {
        //     _HydrochloricAcidAmount -= 0.01f;
        // }
    }

    private void UpdateCopperSulfateContent()
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // This checks if liquid was spilled
            if(_HydrochloricAcidAmount <= 0.4f && whichtesttube == 3)
            {
                // Stop the particles pouring
                // _HydrochloricAcidPour.Stop();

                Invoke("CheckTransferHydrochloricAcid",1f);
            }
             if(_HydrochloricAcidAmount <= 0f && whichtesttube == 6)
            {
                // Stop the particles pouring
                // _HydrochloricAcidPour.Stop();

                Invoke("CheckTransferHydrochloricAcid",1f);
            }
            // Get the Renderer component of the GameObject
            Renderer ChemRenderer = _HydrochloricAcidCont.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = ChemRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");

                // Equate to static variable na connected sa test tube
                fillValue = _HydrochloricAcidAmount;

                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);

                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);
            }
        }
    }

    private void CheckTransferHydrochloricAcid()
    {
        
        if(whichtesttube == 3)
        {
            if(s4TestTube3._s4Tube3Amount >= 0.8f && !success) 
            {
                // Transfer Success
                success = true;
                if(GameMngr.S4currentsteps == 3)
                {
                    GameMngr.S4currentsteps = 4;
                    vrRobot.currentStepExecuted4 = false;
                }
                
                Debug.Log("Hydrochloric Acid transfer success 3.");
            }
        }

        if(whichtesttube == 6)
        {
            if(s4TestTube6._s4Tube6Amount >= 0.8f && !success2) 
            {
                // Transfer Success2
                success2 = true;
                if(GameMngr.S4currentsteps == 6)
                {
                    GameMngr.S4currentsteps = 7;
                    vrRobot.currentStepExecuted4 = false;
                }
                
                Debug.Log("Hydrochloric Acid transfer success 6.");
            }
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
