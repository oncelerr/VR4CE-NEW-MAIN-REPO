using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ignitionMatch : MonoBehaviour
{
    [SerializeField] ParticleSystem matchFire;
    public bool ignitedMatchStick = false;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("matchbox")) 
        {
            ignitedMatchStick = true;
            matchFire.Play();
        }
        if(other.CompareTag("table")) 
        {
            ignitedMatchStick = false;
            matchFire.Stop();
        }
    }
}
