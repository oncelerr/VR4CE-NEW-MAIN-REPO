using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sim2Player : MonoBehaviour
{
    [SerializeField] PPE _PPE;
    private void OnTriggerEnter(Collider other) 
    {
        // Wear Labcoat
        if(other.gameObject.CompareTag("labcoat"))
        {
            PPE.coatReady = true;
            _PPE.Labcoat.SetActive(false);
            PPE.PPEclist = 1;
        }

        // Wear Goggles
        if(other.gameObject.CompareTag("goggles"))
        {
            PPE.gogglesReady = true;
            _PPE.Goggles.SetActive(false);
            PPE.PPEclist = 3;
        }
    }
    
}
