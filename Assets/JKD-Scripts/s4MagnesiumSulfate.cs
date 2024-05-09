using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s4MagnesiumSulfate : MonoBehaviour
{
    ParticleSystem _MagnesiumSulfatePour;
    private Material material;
    public GameObject _MagnesiumSulfateCont;
    private bool success = false;
    private bool wasted = false;    
    public static float _MagnesiumSulfateAmount = 0.4f;


    void Start()
    {
        _MagnesiumSulfatePour = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        float angle = Vector3.Angle(Vector3.down, transform.forward);
        if (angle <= 70f && s4TestTube5._s4Tube5Amount < 0.8f)
        {
            _MagnesiumSulfatePour.Play();
        }
        else
        {
            _MagnesiumSulfatePour.Stop();
        }
        UpdateMagnesiumSulfateContent();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("tube5"))
        {
            if(s4TestTube5._s4Tube5Amount < 0.8f && s4TestTube5._s4SubStep5 == 1)
            {
                // will increment the fill value of the container
                s4TestTube5._s4Tube5Amount += 0.01f;
                _MagnesiumSulfateAmount -= 0.01f;
            }
        }
        // else if(_SilverNitrateAmount > 0) // This check if the player spilled the liquid
        // {
        //     _SilverNitrateAmount -= 0.01f;
        // }
    }

    private void UpdateMagnesiumSulfateContent()
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // This checks if liquid was spilled
            if(_MagnesiumSulfateAmount <= 0f)
            {
                // Stop the particles pouring
                // _SilverNitratePour.Stop();

                Invoke("CheckMagnesiumSulfate",1f);
            }
            // Get the Renderer component of the GameObject
            Renderer ChemRenderer = _MagnesiumSulfateCont.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = ChemRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");

                // Equate to static variable na connected sa test tube
                fillValue = _MagnesiumSulfateAmount;

                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);

                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);
            }
        }
    }

    private void CheckMagnesiumSulfate()
    {
        if(s4TestTube5._s4Tube5Amount >= 0.8f && !success) 
        {
            // Transfer Success
            success = true;
            if(GameMngr.S4currentsteps == 5)
            {
                GameMngr.S4currentsteps = 6;
                vrRobot.currentStepExecuted4 = false;
            }
            
            Debug.Log("Magnesium sulfate transfer success.");
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
