using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMngr : MonoBehaviour
{
    public Rigidbody[] hoses; 

    void Start()
    {
        ActivatePhysics();
        Invoke("DeactivatePhysics",1f);
    }

    private void ActivatePhysics()  //Turn on gravity
    {
        for (int i = 0; i < hoses.Length; i++)
        {
           hoses[i].useGravity = true;
           hoses[i].isKinematic = false;
        }
    }

    private void DeactivatePhysics()  //Turn off gravity
    {
        for (int i = 0; i < hoses.Length; i++)
        {
           hoses[i].useGravity = false;
           hoses[i].isKinematic = true;
        }
    }
}
