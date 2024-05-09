using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyTransformWithOffset : MonoBehaviour
{
    public Transform sourceObject; // The object whose position and rotation will be copied
    public Transform targetObject; // The object that will receive the copied position and rotation

    public Vector3 copierOffset = new Vector3(5f, 5f, 5f); // Offset values for the copier's own position

    void Update()
    {
        if (sourceObject != null && targetObject != null)
        {
            // Copy the position and rotation from sourceObject to targetObject
            targetObject.position = sourceObject.position;
            targetObject.rotation = sourceObject.rotation;

            // Apply the copier's offset to maintain the relative position
            targetObject.position += targetObject.TransformVector(copierOffset);
        }
        else
        {
            Debug.LogWarning("Source or target object is not assigned!");
        }
    }
}


