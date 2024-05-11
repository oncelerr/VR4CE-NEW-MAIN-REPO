using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class termsbut : MonoBehaviour
{
    public GameObject button;
    public Material newMaterial;
    private Material originalMaterial;


    public GameObject objectToEnable; // Object to enable when button is pressed

    private bool isPressed = false;
    private GameObject presser;

    void Start()
    {
        Renderer buttonRenderer = button.GetComponent<Renderer>();
        if (buttonRenderer != null)
        {
            originalMaterial = buttonRenderer.material;
        }
        else
        {
            Debug.LogWarning("Button Renderer not found.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.001f, -0.003f);
            Renderer buttonRenderer = button.GetComponent<Renderer>();
            if (buttonRenderer != null)
            {
                buttonRenderer.material = newMaterial;
            }
            else
            {
                Debug.LogWarning("Button Renderer not found.");
            }

            presser = other.gameObject;
            isPressed = true;

            if (objectToEnable != null)
            {
                objectToEnable.SetActive(true); // Enable the assigned object
            }
            else
            {
                Debug.LogWarning("No object assigned to enable!");
            }

        
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.013f, -0.016f);
            Renderer buttonRenderer = button.GetComponent<Renderer>();
            if (buttonRenderer != null)
            {
                buttonRenderer.material = originalMaterial;
            }
            else
            {
                Debug.LogWarning("Button Renderer not found.");
            }
            isPressed = false;
        }
    }

  
}
