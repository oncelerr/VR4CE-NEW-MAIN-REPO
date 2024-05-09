using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ObjectFollowCamera : MonoBehaviour
{
    public Vector3 positionOffset = new Vector3(0f, 0f, 2f); // Adjust the offset as needed
    private Camera vrCamera;

    void Start()
    {
        // Find the VR camera in the scene
        vrCamera = Camera.main;

        if (vrCamera == null)
        {
            Debug.LogError("VR camera not found. Make sure your camera is tagged as 'MainCamera' in your VR setup.");
            enabled = false;
        }
    }

    void Update()
    {
        transform.position = vrCamera.transform.position + vrCamera.transform.TransformDirection(positionOffset);
        transform.rotation = vrCamera.transform.rotation;
    }
}
