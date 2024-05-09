using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aluminum : MonoBehaviour
{
    ParticleSystem aluminumPour;
    private Material material;
    public GameObject _aluminumContentObj;
    private bool firsAlDrop;
    private bool success;
    private bool wasted;

    public static float AluminumAmount = 0.25f;

    void Start()
    {
        aluminumPour = GetComponent<ParticleSystem>();
        firsAlDrop = false;
    }

    void Update()
    {
        // THis check if the the player is pouring a liquid/powder
        float angle = Vector3.Angle(Vector3.down, transform.forward);
        if (angle <= 60f && mixingBeakerContent.aluminumValue < 0.26f)
        {
            aluminumPour.Play();
        }
        else
        {
            aluminumPour.Stop();
        }
        // Update aluminum content
        UpdateAluminumContent();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("mixingBeakerPourArea"))
        {
            // Debug.Log("Colliding with mixing beaker");
            // Check niya if the empty beaker ay nareach na yung amount of the aluminum 
            if(mixingBeakerContent.aluminumValue < 0.41f)
            {
                if(firsAlDrop)
                {
                    firsAlDrop = false;
                    mixingBeakerContent.aluminumValue += 0.25f;
                }
                // Dito iicrement niya yung value nung sa empty beaker para kunwari nafifill yung beaker
                mixingBeakerContent.aluminumValue += 0.01f;
                AluminumAmount -= 0.01f;
            }
        }
        else if (AluminumAmount > 0)
        {
            AluminumAmount -= 0.01f;
        }
    }
    
    private void UpdateAluminumContent() 
    {
        if(GameMngr.CurrentLevelIndex == 2 && mixingBeaker.isItHoldingAluminumBeaker)
        {
            // Debug.Log("Aluminum in the AB: " +AluminumAmount);
            // Debug.Log("Aluminum in the EB: " +mixingBeakerContent.aluminumValue);
            if (AluminumAmount <= 0f)
            {
                // Stop particle pouring
                aluminumPour.Stop();

                Invoke("CheckTransferPowderAl", 1f);  
            }

            // Get the Renderer component of the GameObject
            Renderer aluminumRenderer = _aluminumContentObj.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = aluminumRenderer.material;  

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");

                // Equate to static variable na connected sa beaker
                fillValue = AluminumAmount;

                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);

                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);

                // Debug.Log("Aluminum Current Fill Value: " + fillValue);
            }
            else
            {
                Debug.LogError("Aluminum Material does not have a _Fill property");
            }
        }
    }

    private void CheckTransferPowderAl()
    {
        if (mixingBeakerContent.aluminumValue >= 0.4f && !success)
        {
            // Transfer success
            success = true;
            GameMngr.S2currentsteps = 2;
            vrRobot.currentStepExecuted2 = false;
            mixingBeakerContent.aluminumTransferSuccess = true;
            Debug.Log("Aluminum transfer success");
        }
        else if (mixingBeakerContent.aluminumValue < 0.34f && !wasted)
        {
            // Aluminum powder wasted
            wasted = true;
            mixingBeakerContent.aluminumTransferSuccess = false;
            Debug.Log("Aluminum powder wasted.");
            GameMngr.S2SpilledChemPowder = true; // trigger if the player spilled a powder
        } 
    }
}
