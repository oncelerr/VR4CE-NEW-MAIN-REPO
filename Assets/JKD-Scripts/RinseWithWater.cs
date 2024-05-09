using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RinseWithWater : MonoBehaviour
{
    public static bool alreadyRinseWWater = false;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Human"))
        {
            alreadyRinseWWater = true;
            Debug.Log("Left hand already rinse with water.");
        }

        if(other.gameObject.CompareTag("Right Hand"))
        {
            if(GameMngr.S1currentsteps == 2f)
            {
                vrRobot.currentStepExecuted = false;
                GameMngr.S1currentsteps = 3f;
            }
            alreadyRinseWWater = true;

            Debug.Log("Right hand already rinse with water.");
        }
    }
}
