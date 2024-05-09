using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBeaker : MonoBehaviour
{
    public static bool _PipeCollidedWithWater;
    [SerializeField]  CapsuleCollider _WaterCapsColl;


    private void Start()
    {
        _PipeCollidedWithWater = false;
    }
    
    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag("Pipette"))
        {
            _PipeCollidedWithWater = true;
            _WaterCapsColl.enabled = false;
        }
    }
    
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Pipette"))
        {
            _PipeCollidedWithWater = false;
            _WaterCapsColl.enabled = true;
        }
    }
}
