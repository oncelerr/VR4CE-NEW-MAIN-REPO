using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class s4TestTube2 : MonoBehaviour
{
    [SerializeField] private GameObject _Tube2SilverNitrateCont;
    public static float _s4Tube2Amount;
    public static int _s4SubStep2 = 0;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Copper"))
        {
            DOTween.Pause("p10"); // Pause ppe subtitles; for debugging purposes only
            _s4SubStep2 = 1;
             if(s4Copper.WhichCopper == 1)
            {
                s4Copper.Copper1 = true;
                s4Copper.CopperCoatedFX = true;
            }
            if(s4Copper.WhichCopper == 2)
            {
                s4Copper.Copper2 = true;
                s4Copper.CopperCoatedFX = true;
            }
            Debug.Log("Copper added to test tube 2.");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Copper"))
        {
            
            Debug.Log("Copper missed in test tube 2.");
        }
    }
    
    private void Update() 
    {
        UpdateSilverNitrateContent();
    }

    private void UpdateSilverNitrateContent() 
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // Get the Renderer component of the GameObject
            Renderer tubeRenderer = _Tube2SilverNitrateCont.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = tubeRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");
                // Equate to static variable na connected sa beaker
                fillValue = _s4Tube2Amount;
                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);
                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);
            }
        }
    }
}
