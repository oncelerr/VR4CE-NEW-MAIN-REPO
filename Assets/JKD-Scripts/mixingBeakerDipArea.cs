using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixingBeakerDipArea : MonoBehaviour
{
    public Transform _mixingBeakerT;
    public Transform _mixingBeakerDipAreaT;
    public float angleThreshold;
    // public float followSpeed = 0.0001f; 

    public static bool pippetteWaterDrop;

    private void Start() 
    {
        pippetteWaterDrop = false;
    }
    private void Update() 
    {
        FollowObject(_mixingBeakerT, _mixingBeakerDipAreaT);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Pipette"))
        {
            if(MixingArea.isMixingDone)
            {
                pippetteWaterDrop = true;
                GameMngr.S2currentsteps = 5;
                vrRobot.currentStepExecuted2 = false;
            }
        }
    }

    private void FollowObject(Transform ObjectToFollow, Transform Follower)
    {
        // Declare targetPosition outside the if-else block
        Vector3 targetPosition;

        // Calculate the angle between ObjectToFollow's down vector and transform's forward vector
        float angle = Vector3.Angle(Vector3.down, transform.forward);

        if (angle <= angleThreshold && mixingBeakerContent.iodineValue < 0.26f)
        {
            // Set targetPosition to ObjectToFollow's position without any offset
            targetPosition = new Vector3(ObjectToFollow.position.x, ObjectToFollow.position.y, ObjectToFollow.position.z);
        }
        else
        {
            // Set targetPosition to ObjectToFollow's position with an offset in the y component
            targetPosition = new Vector3(ObjectToFollow.position.x, ObjectToFollow.position.y - 0.0347f, ObjectToFollow.position.z);
        }

        // Set the Follower's position to the new targetPosition
        Follower.position = targetPosition;
    }
}
