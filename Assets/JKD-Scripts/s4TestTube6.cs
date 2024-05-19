using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class s4TestTube6 : MonoBehaviour
{
    [SerializeField] private GameObject _HydrochloricAcidCont;
    public static float _s4Tube6Amount;
    public static int _s4SubStep6 = 0;

    private void Start() 
    {
        // reset vars
        _s4Tube6Amount = 0f;
        _s4SubStep6 = 0;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Zinc"))
        {
            DOTween.Pause("p10"); // Pause ppe subtitles; for debugging purposes only
            _s4SubStep6 = 1;
            if(s4Zinc.WhichZinc == 1)
            {
                s4Zinc.Zinc1isChosen = true;
                s4Zinc.ZincBubblesFX1 = true;
            }
            if(s4Zinc.WhichZinc == 2)
            {
                s4Zinc.Zinc2isChosen = true;
                s4Zinc.ZincBubblesFX2 = true;
            }
            if(s4Zinc.WhichZinc == 3)
            {
                s4Zinc.Zinc3isChosen = true;
                s4Zinc.ZincBubblesFX3 = true;
            }
            Debug.Log("Zinc added to test tube 6.");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Zinc"))
        {
            
            Debug.Log("Zinc missed in test tube 6.");
        }
    }
    
    private void Update() 
    {
        UpdateHydrochloricAcidContent();
    }

    private void UpdateHydrochloricAcidContent() 
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // Get the Renderer component of the GameObject
            Renderer tubeRenderer = _HydrochloricAcidCont.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = tubeRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");
                // Equate to static variable na connected sa beaker
                fillValue = _s4Tube6Amount;
                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);
                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);
            }
        }
    }
}
