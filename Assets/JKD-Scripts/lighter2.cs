using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class lighter2 : MonoBehaviour
{
    [SerializeField] AudioMngr  _AudioMngr;
    [SerializeField] ParticleSystem LighterFire;

    public void LighterON(bool State)
    {
        if(State) 
        {
            LighterFire.Play();
            _AudioMngr.Lighter2ON();
        }
        else
        {
            LighterFire.Stop();
            _AudioMngr.Lighter2OFF();
        }
    }    
}
