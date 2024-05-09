using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S3Burner : MonoBehaviour
{
    private bool s3burnAlreadyIgnited;
    public ParticleSystem s3BurnerFire;
    public static float s3BurnerFireAmount;

    private void Start() 
    {
        s3BurnerFireAmount = 0.5f;
        s3burnAlreadyIgnited = false;
        s3BurnerFire.Stop();
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("lighterFire"))
        {
            if(!s3burnAlreadyIgnited && GameMngr.S3currentsteps == 4)
            {
                s3burnAlreadyIgnited = true;
                s3BurnerFire.Play();
                GameMngr.S3currentsteps = 5;
                vrRobot.currentStepExecuted3 = false;
                Debug.Log("Burner is on.");
            }
        }
    }
}
