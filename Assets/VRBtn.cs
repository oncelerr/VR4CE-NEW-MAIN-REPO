using UnityEngine;

public class VRBtn : MonoBehaviour
{
    public GameObject button;
    public Material newMaterial;
    public Material originalMaterial;

    public GameObject objectToActivate; // Object to activate when the button is pressed
    public GameObject objectToActivate1; // Object to activate when the button is pressed
    public GameObject objectToDisable; // Object to disable when the button is pressed
    public GameObject objectToDisable1; // Object to disable when the button is pressed
    private bool isPressed = false;
    private GameObject presser;

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
            button.transform.localPosition = new Vector3(0, 0.001f, -0.003f);
            Renderer buttonRenderer = button.GetComponent<Renderer>();
            if (buttonRenderer != null)
            {
                buttonRenderer.material = newMaterial;
            }

            presser = other.gameObject;
            isPressed = true;

            PlayerPrefs.SetInt("isAgree", 4);
            PlayerPrefs.Save();

            // Activate the assigned object if exists
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
               if (objectToActivate1 != null)
            {
                objectToActivate1.SetActive(true);
            }

            // Disable the assigned object if exists
            if (objectToDisable != null)
            {
                objectToDisable.SetActive(false);
            }
              if (objectToDisable1 != null)
            {
                objectToDisable1.SetActive(false);
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
            isPressed = false;
        }
    }
}

