using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class s4TestTube1 : MonoBehaviour
{
    [SerializeField] private GameObject _Tube1CopperSulfateCont;
    public static float _s4Tube1Amount;
    public static int _s4SubStep1 = 0;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Magnesium"))
        {
            DOTween.Pause("p10"); // Pause ppe subtitles; for debugging purposes only
            GameMngr.S4currentsteps = 1f;
            _s4SubStep1 = 1;
            if(s4Magnesium.WhichMagnesium == 1)
            {
                s4Magnesium.Magnesium1 = true;
                s4Magnesium.DissolveFX = true;
            }
            if(s4Magnesium.WhichMagnesium == 2)
            {
                s4Magnesium.Magnesium2 = true;
                s4Magnesium.DissolveFX = true;
            }
            vrRobot.currentStepExecuted4 = false; 
            Debug.Log("Magnesium added to test tube 1.");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Magnesium"))
        {
            Debug.Log("Magnesium missed in test tube 1.");
        }
    }
    
    private void Update() 
    {
        UpdateCopperSulfateContent();
    }

    private void UpdateCopperSulfateContent() 
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // Get the Renderer component of the GameObject
            Renderer tubeRenderer = _Tube1CopperSulfateCont.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = tubeRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");
                // Equate to static variable na connected sa beaker
                fillValue = _s4Tube1Amount;
                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);
                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);
            }
        }
    }
}
