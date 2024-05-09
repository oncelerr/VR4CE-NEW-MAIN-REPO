using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHandsPos : MonoBehaviour
{
    public Transform RightHandToFollow;
    public Transform RightFireFollower;
    public float followSpeed = 0.0001f; 

    private void Update() 
    {
        // Calculate the desired position based on the target's position
        Vector3 targetPositionR = RightHandToFollow.position;
        // Vector3 targetPositionL = LeftHandToFollow.position;

        // Smoothly move towards the target position
        RightFireFollower.position = Vector3.Lerp(RightFireFollower.position, targetPositionR, followSpeed * Time.deltaTime);
        // LeftFireFollower.position = Vector3.Lerp(LeftFireFollower.position, targetPositionL, followSpeed * Time.deltaTime);
    }
}
