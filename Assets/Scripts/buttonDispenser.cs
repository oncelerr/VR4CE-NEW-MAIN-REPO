using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class buttonDispenser : MonoBehaviour
{
    public GameObject button;
    public Material newMaterial;
    public Material originalMaterial;

    private bool isPressed = false;
    private GameObject presser;

    public AudioClip waterDispenserSound;

    void Start()
    {
        Renderer buttonRenderer = button.GetComponent<Renderer>();
        if (buttonRenderer != null)
        {
            originalMaterial = buttonRenderer.material;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0.116f, -0.02824f, -0.002f);
            Renderer buttonRenderer = button.GetComponent<Renderer>();
            if (buttonRenderer != null)
            {
                buttonRenderer.material = newMaterial;
            }

            presser = other.gameObject;
            isPressed = true;

            // Start the coroutine to dispense water repeatedly
            StartCoroutine(DispenseWaterRepeatedly());

            // Play sound effect
            if (waterDispenserSound != null)
            {
                AudioSource.PlayClipAtPoint(waterDispenserSound, transform.position);
            }
            else
            {
                Debug.LogWarning("Water dispenser sound effect is not assigned.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0.11567f, -0.02824f, -0.016f);
            Renderer buttonRenderer = button.GetComponent<Renderer>();
            if (buttonRenderer != null)
            {
                buttonRenderer.material = originalMaterial;
            }
            isPressed = false;

            // Stop the coroutine when the button is released
            StopCoroutine(DispenseWaterRepeatedly());
        }
    }

    private IEnumerator DispenseWaterRepeatedly()
    {
        float timeBetweenDuplicates = 0.01f; // Adjust as needed for desired duplication rate
        while (isPressed)
        {
            dispenseWater();
            yield return new WaitForSeconds(timeBetweenDuplicates);
        }
    }

    private void dispenseWater()
    {
        
        GameObject[] waterObjects = GameObject.FindGameObjectsWithTag("water");
        foreach (GameObject waterObject in waterObjects)
        {
            Debug.Log("Duplicating water object: " + waterObject.name);
            GameObject newWater = Instantiate(waterObject);
            newWater.transform.position = waterObject.transform.position;
            newWater.transform.rotation = waterObject.transform.rotation;
            newWater.transform.localScale = new Vector3(0.010000001f, 0.010000001f, 0.010000001f); // Copy scale
            newWater.tag = "dupedWater";

            MeshRenderer meshRenderer = newWater.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                meshRenderer.enabled = true;
            }

            // Add Rigidbody component
            Rigidbody rb = newWater.AddComponent<Rigidbody>();
            // Add SphereCollider component
            SphereCollider sphereCollider = newWater.AddComponent<SphereCollider>();
            // Adjust the properties of the SphereCollider if needed
        }
    }
}
