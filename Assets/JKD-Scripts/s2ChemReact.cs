using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2ChemReact : MonoBehaviour
{

    // private void OnTriggerStay(Collider other) 
    // {
    //     if(other.gameObject.CompareTag("iodineL")) 
    //     {
            
    //     }
    // }


    public string variableName = "_Fill"; // Name of the surface input variable

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            Material mat = renderer.sharedMaterial; // Get the material

            // Check if the material has the desired variable
            if (mat.HasProperty(variableName))
            {
                float value = mat.GetFloat(variableName); // Get the value of the variable
                Debug.Log("Value of " + variableName + ": " + value);
            }
            else
            {
                Debug.LogError("Material does not have property: " + variableName);
            }
        }
        else
        {
            Debug.LogError("Renderer component not found.");
        }
    }

}
