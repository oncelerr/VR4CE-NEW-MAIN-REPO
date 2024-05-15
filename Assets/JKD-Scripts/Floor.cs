using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Floor : MonoBehaviour
{
    [SerializeField] ScoreMngr _ScoreMngr;


    private void OnTriggerEnter(Collider other) 
    {
        // List of objects to deduct
        if(other.gameObject.CompareTag("beaker"))
        {
            Debug.Log("Beaker or test tube dropped");
            _ScoreMngr.Deductions("DropBeakerTube");
        }
        if(other.gameObject.CompareTag("testtube"))
        {
            Debug.Log("Beaker or test tube dropped");
            _ScoreMngr.Deductions("DropBeakerTube");
        }

    }
}
