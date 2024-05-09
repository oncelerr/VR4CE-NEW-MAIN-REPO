using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class doorAnimation2 : MonoBehaviour
{
    [SerializeField] AudioMngr _AudioMngr;
    public Vector3 OrigPos2;
    public Vector3 TargetPos2;
    public float speed = 1f;
    [SerializeField] Transform Door2;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Human"))
        {
            OpenDoor2();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Human"))
        {
            CloseDoor2();
        }
    }


    public void OpenDoor2()
    {
        Door2.DOMove(TargetPos2, speed);
        _AudioMngr.DoorFX(true);
    }

    public void CloseDoor2()
    {
        Door2.DOMove(OrigPos2, speed);
        _AudioMngr.DoorFX(false);
    }
}
