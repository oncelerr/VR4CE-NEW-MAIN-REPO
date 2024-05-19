using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class s2SplashTrigger : MonoBehaviour
{
    [SerializeField] ScoreMngr _ScoreMngr;


    private void OnTriggerEnter(Collider other) 
    {
        // List of objects to deduct
        if(other.gameObject.CompareTag("Human"))
        {
            _ScoreMngr.Deductions("ChemNotYetDone");
        }
    }
}
