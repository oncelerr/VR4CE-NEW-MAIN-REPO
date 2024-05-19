using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sim2Player : MonoBehaviour
{
    [SerializeField] AudioMngr _AudioMngr;
    [SerializeField] PPE _PPE;
    private void OnTriggerEnter(Collider other) 
    {
        // Wear Labcoat
        if(other.gameObject.CompareTag("labcoat"))
        {
            _AudioMngr.WearCoatFX();
            PPE.coatReady = true;
            _PPE.Labcoat.SetActive(false);
            PPE.PPEclist = 1;
        }

        // Wear Goggles
        if(other.gameObject.CompareTag("goggles"))
        {
            _AudioMngr.WearGogglesFX();
            PPE.gogglesReady = true;
            _PPE.Goggles.SetActive(false);
            PPE.PPEclist = 3;
        }
    }
    
}
