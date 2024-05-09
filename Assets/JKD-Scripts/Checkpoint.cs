using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] ParticleSystem[] CPoint;
    [SerializeField] GameObject[] CPointGO;
    public static int _CheckpointIndexSub1 = 1; //There are 1 checkpoint in sublevel 1
    public static int _CheckpointIndexSub2 = 2; //There are 2 checkpoint in sublevel 2
    public static int _CheckpointIndexSub3 = 4; //There are 1 checkpoint in sublevel 3
    public static int _CheckpointIndexSub4 = 5; //There are 2 checkpoint in sublevel 4
    public static int _CheckpointIndexSub5 = 7; //There are 1 checkpoint in sublevel 5

    public void ShowCheckpoint(int CP)
    {
        CPointGO[CP].SetActive(true);
        CPoint[CP].Play();
    }
}
