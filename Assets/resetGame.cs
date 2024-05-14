using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetGame : MonoBehaviour
{
    public GameObject button;
    public Material newMaterial;
    public Material originalMaterial;

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
            button.transform.localPosition = new Vector3(0.116f, -0.02824f, -0.002f);
            Renderer buttonRenderer = button.GetComponent<Renderer>();
            if (buttonRenderer != null)
            {
                buttonRenderer.material = newMaterial;
            }

            presser = other.gameObject;
            isPressed = true;

            PlayerPrefs.GetInt("IsTutorialDone", 0);
            PlayerPrefs.GetInt("IsMassRDone", 0);
            PlayerPrefs.GetInt("IsChemRDone", 0);
            PlayerPrefs.Save();
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
        }
    }
}
