using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnMoleculeFirst : MonoBehaviour
{
    public GameObject button;
    public Material newMaterial;
    public Material originalMaterial;
    public GameObject molecule;
    public GameObject parent;
    public GameObject hint;

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
            if (other.CompareTag("Left Hand") || other.CompareTag("Right Hand"))
            {
                button.transform.localPosition = new Vector3(0, -0.00350000011f, 0.0137999998f);
                Renderer buttonRenderer = button.GetComponent<Renderer>();
                if (buttonRenderer != null)
                {
                    buttonRenderer.material = newMaterial;
                }
                dupeMole();
                hint.SetActive(false);
                presser = other.gameObject;
                isPressed = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, -0.00480000023f, 0.0137999998f);
            Renderer buttonRenderer = button.GetComponent<Renderer>();
            if (buttonRenderer != null)
            {
                buttonRenderer.material = originalMaterial;
            }
            isPressed = false;
        }
    }

    public void dupeMole()
    {
        if (molecule != null && parent != null)
        {
            // Instantiate the molecule as a child of the parent GameObject
            GameObject duplicatedMolecule = Instantiate(molecule, parent.transform);
            duplicatedMolecule.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Molecule GameObject or Parent GameObject is not assigned.");
        }
    }
}
