using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iodine : MonoBehaviour
{
    ParticleSystem iodinePour;
    private Material material;
    public GameObject _iodineContentObj;
    private bool success = false;
    private bool wasted = false;
     


    public static float IodineAmount = 0.25f;

    void Start()
    {
        iodinePour = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        float angle = Vector3.Angle(Vector3.down, transform.forward);
        if (angle <= 60f && mixingBeakerContent.iodineValue < 0.26f)
        {
            iodinePour.Play();
        }
        else
        {
            iodinePour.Stop();
        }
        UpdateIodineContent();
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("mixingBeakerPourArea"))
        {
            // Debug.Log("Colliding with mixing beaker");
            // Check niya if the empty beaker ay nareach na yung amount of the iodine
            if(mixingBeakerContent.iodineValue < 0.26f)
            {
                // Dito iicrement niya yung value nung sa empty beaker para kunwari nafifill yung beaker
                mixingBeakerContent.iodineValue += 0.01f;
                IodineAmount -= 0.01f;
            }
        }
        else if(IodineAmount > 0)
        {
            IodineAmount -= 0.01f;
        }
    }
    private void UpdateIodineContent() 
    {
        if(GameMngr.CurrentLevelIndex == 2 && mixingBeaker.isItHoldingIodineBeaker)
        {
            // Debug.Log("Iodine in the IB: " +IodineAmount);
            // Debug.Log("Iodine in the EB: " +mixingBeakerContent.iodineValue);
            if(IodineAmount <= 0f)
            {
                // Stop the particles pouring
                iodinePour.Stop();

                Invoke("CheckTransferPowderIo",1f);
            }
            // Get the Renderer component of the GameObject
            Renderer iodineRenderer = _iodineContentObj.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = iodineRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");

                // Equate to static variable na connected sa beaker
                fillValue = IodineAmount;

                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);

                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);

                // Debug.Log("Iodine Current Fill Value: " + fillValue);
            }
            else
            {
                Debug.LogError("Iodine Material does not have a _Fill property");
            }
        }
    }

    private void CheckTransferPowderIo()
    {
        if(mixingBeakerContent.iodineValue >= 0.25f && !success) 
        {
            // Transfer Success
            success = true;
            GameMngr.S2currentsteps = 1;
            mixingBeakerContent.iodineTransferSuccess = true;
            Debug.Log("Iodine transfer success");
        }
        else if(mixingBeakerContent.iodineValue < 0.22f && !wasted)
        {
            // Iodine liquid wasted
            wasted = true;
            Debug.Log("Iodine powder wasted.");
            GameMngr.S2SpilledChemPowder = true; // trigger if the player spilled a powder
            mixingBeakerContent.iodineTransferSuccess = false;
        }
    }
}
