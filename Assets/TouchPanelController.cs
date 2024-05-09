using UnityEngine;

public class TouchPanelController : MonoBehaviour
{
    public GameObject panel; // Reference to the panel to open/close
    public GameObject hand; // Reference to the hand GameObject
    public GameObject objectToDisable; // Reference to the object to disable

    private bool handTouching = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == hand)
        {
            handTouching = true;
            // Open the panel
            OpenPanel();
            // Disable the object
            DisableObject();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == hand)
        {
            handTouching = false;
            // Close the panel
            ClosePanel();
            // Enable the object
            EnableObject();
        }
    }

    private void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Panel reference is not set in TouchPanelController.");
        }
    }

    private void ClosePanel()
    {
        if (panel != null && !handTouching)
        {
            panel.SetActive(false);
        }
    }

    private void DisableObject()
    {
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Object to disable reference is not set in TouchPanelController.");
        }
    }

    private void EnableObject()
    {
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
    }
}
