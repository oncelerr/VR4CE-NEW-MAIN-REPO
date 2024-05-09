using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class triggerZoneGloves : MonoBehaviour
{
    public string targetTag;
    public UnityEvent<GameObject> OnEnterEvent;
    public Material newMaterial; // Reference to the new material to be applied
    private bool done = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag) && !done)
        {
            OnEnterEvent.Invoke(other.gameObject);
            done = true;
            
        }
    }

    // Method to change the material of the collided GameObject
    public void ChangeMaterial(GameObject obj)
    {
        Renderer rend = obj.GetComponent<Renderer>();
        if (rend != null && newMaterial != null)
        {
            rend.material = newMaterial;
        }
    }
}
