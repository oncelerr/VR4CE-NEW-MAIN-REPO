using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndependentMovement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the "sugar" tag
        if (other.CompareTag("sugar"))
        {
            Debug.Log("Sugar entered the trigger zone.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object has the "sugar" tag
        if (other.CompareTag("sugar"))
        {
            Debug.Log("Sugar left the trigger zone.");

            // Get the child object (sphere) of the exiting object
            Transform child = other.transform.GetChild(0);

            // Detach the child object from its parent
            child.SetParent(null);

            // Optional: You can also disable any scripts related to following the parent here
            // For example: child.GetComponent<FollowParentScript>().enabled = false;
        }
    }
}
