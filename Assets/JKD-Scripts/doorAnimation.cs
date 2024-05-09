using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class doorAnimation : MonoBehaviour
{
    [SerializeField] AudioMngr _AudioMngr;
    public Vector3 OrigPos;
    public Vector3 TargetPos;
    public float speed = 1f;
    [SerializeField] Transform Door;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Human"))
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Human"))
        {
            CloseDoor();
        }
    }

    public void OpenDoor()
    {
        Door.DOMove(TargetPos, speed);
        _AudioMngr.DoorFX(true);
    }

    public void CloseDoor()
    {
        Door.DOMove(OrigPos, speed);
        _AudioMngr.DoorFX(false);
    }
}
