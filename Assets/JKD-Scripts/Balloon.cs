using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Balloon : MonoBehaviour
{
    [SerializeField] ScoreMngr _ScoreMngr;


    private void OnTriggerEnter(Collider other) 
    {
        // List of objects to deduct
        if(other.gameObject.CompareTag("lighter"))
        {
            Debug.Log("Player plays with the lighter near the ballon");
            _ScoreMngr.Deductions("PlaysLighter");
        }
    }
}
