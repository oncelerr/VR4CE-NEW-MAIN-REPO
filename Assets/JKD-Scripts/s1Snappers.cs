using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s1Snappers : MonoBehaviour
{
    private bool _Hose1EndSnap;
    private bool _s1activated;
    private void Start() 
    {
        _Hose1EndSnap = false;
        _s1activated = false;
    }
    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag("hoseEnd1")) 
        {
            _Hose1EndSnap = true;
        }
    }
    public void HoseEnd1Snap()
    {
        if(_Hose1EndSnap && !_s1activated)  // add variable here for minus points if the player removes it 
        {
            _s1activated = true;
            GameMngr.S1currentsteps = 1f;
        }
    }
}
