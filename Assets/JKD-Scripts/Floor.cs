using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Floor : MonoBehaviour
{
    [SerializeField] ScoreMngr _ScoreMngr;

    private bool waterBeakerDropped = false;


    private void Start()
    {
        waterBeakerDropped = false;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("beaker"))
        {
            _ScoreMngr.Deductions("DropBeakerTube");
        }
    }
}
