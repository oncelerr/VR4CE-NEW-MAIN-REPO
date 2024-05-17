using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBeakerPour : MonoBehaviour
{
    [SerializeField] ScoreMngr _ScoreMngr;
    ParticleSystem WaterPour;
    public static bool _PipeCollidedWithWater;
    public float BeakerAngle = 151.5f;
    private bool s2Chemwasted = false;

    private void Start()
    {
        // get the component
        WaterPour = GetComponent<ParticleSystem>();
        s2Chemwasted = false;
        _PipeCollidedWithWater = false;
    }

    void Update()
    {
        float angle = Vector3.Angle(Vector3.down, transform.forward);
        if (angle <= BeakerAngle)
        {
            WaterPour.Play();
        }
        else
        {
            WaterPour.Stop();
        }
        // UpdateWaterBeaker();
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("floor"))
        {
            Debug.Log("Particle collided with floor");
            if(!s2Chemwasted)
            {
                s2Chemwasted = true;
                _ScoreMngr.Deductions("SpilledChem");
            }
        }
        if(other.CompareTag("table"))
        {
            Debug.Log("Particle collided with table");
            if(!s2Chemwasted)
            {
                s2Chemwasted = true;
                _ScoreMngr.Deductions("SpilledChem");
            }
        }
        // else if(IodineAmount > 0)
        // {
        //     IodineAmount -= 0.01f;
        // }
    }
    // private void UpdateWaterBeaker() 
    // {
    //     if(GameMngr.CurrentLevelIndex == 2 && mixingBeaker.isItHoldingIodineBeaker)
    //     {
    //         // Debug.Log("Iodine in the IB: " +IodineAmount);
    //         // Debug.Log("Iodine in the EB: " +mixingBeakerContent.iodineValue);
    //         if(IodineAmount <= 0f)
    //         {
    //             // Stop the particles pouring
    //             iodinePour.Stop();

    //             Invoke("CheckTransferPowderIo",1f);
    //         }
    //         // Get the Renderer component of the GameObject
    //         Renderer iodineRenderer = _iodineContentObj.GetComponent<Renderer>();

    //         // Get the material of the Renderer
    //         Material material = iodineRenderer.material;

    //         // Check if the material has a "_Fill" property
    //         if (material.HasProperty("_Fill"))
    //         {
    //             // Get the current fill value from the material
    //             float fillValue = material.GetFloat("_Fill");

    //             // Equate to static variable na connected sa beaker
    //             fillValue = IodineAmount;

    //             // Clamp the fill value to stay within the range 0 to 1
    //             fillValue = Mathf.Clamp01(fillValue);

    //             // Set the fill value in the material
    //             material.SetFloat("_Fill", fillValue);

    //             // Debug.Log("Iodine Current Fill Value: " + fillValue);
    //         }
    //         else
    //         {
    //             Debug.LogError("Iodine Material does not have a _Fill property");
    //         }
    //     }
    // }

}
