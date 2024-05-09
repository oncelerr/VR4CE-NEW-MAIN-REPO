using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class s4TestTube5 : MonoBehaviour
{
    [SerializeField] private GameObject _MagnesiumSulfateCont;
    public static float _s4Tube5Amount;
    public static int _s4SubStep5 = 0;


    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Zinc"))
        {
            DOTween.Pause("p10"); // Pause ppe subtitles; for debugging purposes only
            _s4SubStep5 = 1;
            if(s4Zinc.WhichZinc == 1)
            {
                s4Zinc.Zinc1isChosen = true;
            }
            if(s4Zinc.WhichZinc == 2)
            {
                s4Zinc.Zinc2isChosen = true;
            }
            if(s4Zinc.WhichZinc == 3)
            {
                s4Zinc.Zinc3isChosen = true;
            }
            Debug.Log("Zinc added to test tube 5.");
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Zinc"))
        {
            
            Debug.Log("Zinc missed in test tube 5.");
        }
    }
    
    private void Update() 
    {
        UpdateMagnesiumSulfateContent();
    }

    private void UpdateMagnesiumSulfateContent() 
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            // Get the Renderer component of the GameObject
            Renderer tubeRenderer = _MagnesiumSulfateCont.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = tubeRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");
                // Equate to static variable na connected sa beaker
                fillValue = _s4Tube5Amount;
                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);
                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);
            }
        }
    }
}
