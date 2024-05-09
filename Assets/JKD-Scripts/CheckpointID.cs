using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointID : MonoBehaviour
{
    [SerializeField] AudioMngr _AudioMngr;
    [SerializeField] ParticleSystem CPoint;
    [SerializeField] GameObject CPointGO;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Human"))
        {
            HideCheckpoint();
            if(GameMngr.CurrentLevelIndex == 1)
            {
                Checkpoint._CheckpointIndexSub1++;
            }
            else if(GameMngr.CurrentLevelIndex == 2)
            {
                Checkpoint._CheckpointIndexSub2++;
            }
            else if(GameMngr.CurrentLevelIndex == 3)
            {
                Checkpoint._CheckpointIndexSub3++;
            }
            else if(GameMngr.CurrentLevelIndex == 4)
            {
                Checkpoint._CheckpointIndexSub4++;
            }
            else if(GameMngr.CurrentLevelIndex == 5)
            {
                Checkpoint._CheckpointIndexSub5++;
            }
            // Debug.Log("The check value of sub1 is: "+Checkpoint._CheckpointIndexSub1);
            // Debug.Log("The check value of sub2 is: "+Checkpoint._CheckpointIndexSub2);
            // Debug.Log("The check value of sub3 is: "+Checkpoint._CheckpointIndexSub3);
            // Debug.Log("The check value of sub4 is: "+Checkpoint._CheckpointIndexSub4);
            // Debug.Log("The check value of sub5 is: "+Checkpoint._CheckpointIndexSub5);
        }
    }
    private void HideCheckpoint()
    {
        _AudioMngr.CheckpointFX();
        CPoint.Stop();
        CPointGO.SetActive(false);
    }
}
