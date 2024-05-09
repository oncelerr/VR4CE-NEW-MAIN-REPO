using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class triggerZoneTime : MonoBehaviour
{
    public string targetTag;
    public UnityEvent<GameObject> OnEnterEvent;
    public GameManager gm;
    private bool done = false;
    private bool doneA = false;
    private bool doneB = false;
    private bool doneC = false;
    private bool doneD = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            if(done == false)
            {
                OnEnterEvent.Invoke(other.gameObject);
                done = true;
            }
        }
        else
        {
            if(other.gameObject.tag == "A")
            {
                if(doneA == false)
                {
                    gm.MinusUniversalScore();
                    doneA = true;
                }
            }else if (other.gameObject.tag == "B")
            {
                if (doneB == false)
                {
                    gm.MinusUniversalScore();
                    doneB = true;
                }
            }
            else if (other.gameObject.tag == "C")
            {
                if (doneC == false)
                {
                    gm.MinusUniversalScore();
                    doneC = true;
                }
            }
            else if (other.gameObject.tag == "D")
            {
                if (doneD == false)
                {
                    gm.MinusUniversalScore();
                    doneD = true;
                }
            }

        }
    }
}
