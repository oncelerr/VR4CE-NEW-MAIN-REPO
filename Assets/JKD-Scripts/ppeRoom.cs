using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ppeRoom : MonoBehaviour
{
    [SerializeField] AudioMngr _AudioMngr;
    [SerializeField] HandsMnger _HandsMnger;

    private void Start() 
    {
        _AudioMngr.PlayBGMusic(_AudioMngr.bgMusic[0],true);
    }
    // private void OnTriggerEnter(Collider other) 
    // {
    //     if (other.gameObject.CompareTag("Human"))
    //     {
    //         _AudioMngr.PlayBGMusic(_AudioMngr.bgMusic[0],true);
    //         _AudioMngr.PlayBGMusic(_AudioMngr.bgMusic[1],false);
    //     }
    // }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            // Disable hands interaction until vrBot`s equipment orientation is done
            _HandsMnger.DisableEnableHandsInteraction(false);

            // Check which greetings to main lab will trigger
            switch (GameMngr.CurrentLevelIndex)
            {
                case 1:
                    DOTween.Play("p21");
                    break;
                case 2:
                    DOTween.Play("p51");
                    break;
                case 3:
                    DOTween.Play("p81");
                    break;
                case 4:
                    DOTween.Play("p111");
                    break;
                case 5:
                    DOTween.Play("p141");
                    break;
                default:
                    Debug.LogError("Invalid level index.");
                    break;
            }
            
            _AudioMngr.PlayBGMusic(_AudioMngr.bgMusic[0],false);
            _AudioMngr.PlayBGMusic(_AudioMngr.bgMusic[1],true);
        }
    }
}
