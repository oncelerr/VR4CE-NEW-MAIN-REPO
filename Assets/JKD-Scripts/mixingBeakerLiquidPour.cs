using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixingBeakerLiquidPour : MonoBehaviour
{
    public ParticleSystem _mixingBeakerLiquidPour;
    public GameObject iodineContent;
    public GameObject aluminumContent;
    public GameObject _iodineContentOverall;


    private float iodineContentValue = 0.25f;
    private float aluminumContentValue = 0.4f;
    private float iodineContOverall = 0.4f;

    private bool firstSpill;

    private void Start() 
    {
        firstSpill = true;
    }

    private void Update()
    {
        if(GameMngr.CurrentLevelIndex == 2 && GameMngr.S2currentsteps == 1)
        {
            UpdateMixingBeakerContent(iodineContent, iodineContentValue);
        }
        if(GameMngr.CurrentLevelIndex == 2 && GameMngr.S2currentsteps == 2)
        {
            UpdateMixingBeakerContent(iodineContent, iodineContentValue);
            UpdateMixingBeakerContent(aluminumContent, aluminumContentValue);
        }
        if(GameMngr.CurrentLevelIndex == 2 && GameMngr.S2currentsteps == 3)
        {
            UpdateMixingBeakerContent(_iodineContentOverall, iodineContOverall);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if(GameMngr.CurrentLevelIndex == 2 && GameMngr.S2currentsteps == 1)
        {
            iodineContentValue -= 0.01f;
            aluminumContentValue -= 0.0f;
        }
        if(GameMngr.CurrentLevelIndex == 2 && GameMngr.S2currentsteps == 2)
        {
            iodineContentValue -= 0.01f;
            aluminumContentValue -= 0.01f;
            if(firstSpill)
            {
                firstSpill = false;
                aluminumContentValue -= 0.15f;
            }
        }
        if(GameMngr.CurrentLevelIndex == 2 && GameMngr.S2currentsteps == 3)
        {
            iodineContOverall -= 0.01f;
        }
    }
    private void UpdateMixingBeakerContent(GameObject ContentObjectToUpdate, float ContentValue) 
    {
        if(GameMngr.CurrentLevelIndex == 2 && mixingBeakerContent.isMixingBeakerCurrentlySpilling)
        {
            
            // Get the Renderer component of the GameObject
            Renderer mixingbeakerRenderer = ContentObjectToUpdate.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = mixingbeakerRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");

                // Equate to static variable na connected sa beaker
                fillValue = ContentValue;

                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);

                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);

                // Debug.Log("Iodine Current Fill Value: " + fillValue);
            }
            else
            {
                Debug.LogError("Mixing beaker material does not have a _Fill property");
            }
        }
    }
}
