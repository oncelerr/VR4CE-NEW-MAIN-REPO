using UnityEngine;

public class EnableObjectOnRaycast : MonoBehaviour
{
    public GameObject objectToEnable;
    public float raycastDistance = 10f; // Maximum distance to cast the ray

    // Update is called once per frame
    void Update()
    {
        // Check for input from the VR controller (e.g., Oculus Touch or Vive Wand)
        if (Input.GetButtonDown("Fire1")) // Change "Fire1" to the appropriate input for your VR platform
        {
            // Create a ray from the controller's position and forward direction
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            // Cast the ray and check if it hits the object
            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                if (hit.collider.gameObject == gameObject) // Check if the ray hits this object
                {
                    // Enable the object when the button is hit by the ray
                    objectToEnable.SetActive(true);
                }
            }
        }
    }
}
