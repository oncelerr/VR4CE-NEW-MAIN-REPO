using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class mixingBeakerContent : MonoBehaviour
{
    [SerializeField] ScoreMngr _ScoreMngr;
    [SerializeField] AudioMngr _AudioMngr;
    public GameObject mixingBeakerContentObj;
    public GameObject aluminumContent;
    public static float iodineValue = 0f;
    public static float aluminumValue = 0f;

    // Variables for checking if the powder is already transfer
    public static bool iodineTransferSuccess;
    public static bool aluminumTransferSuccess;

    private bool mixingbeakercontWasted = false;
    private void Start() 
    {
        // Reset variables
        iodineValue = 0f;
        aluminumValue = 0f;
        iodineTransferSuccess = false;
        aluminumTransferSuccess = false;
    }
    private void Update()
    {
        FillBeaker(iodineValue, mixingBeakerContentObj, mixingBeaker.isItHoldingIodineBeaker);
        FillBeaker(aluminumValue, aluminumContent, mixingBeaker.isItHoldingAluminumBeaker);

    }

    public void FillBeaker(float Liquid, GameObject content, bool beakerHolding)
    {
        if(GameMngr.CurrentLevelIndex == 2 && beakerHolding)
        {
            // Get the Renderer component of the GameObject
            Renderer iodineRenderer = content.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = iodineRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");

                // Equate to static variable na connected sa beaker
                fillValue = Liquid;

                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);

                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);

                // Debug.Log("Current Fill Value: " + fillValue);
            }
            else
            {
                Debug.LogError("Material does not have a _Fill property");
            }
        }
    }
}
