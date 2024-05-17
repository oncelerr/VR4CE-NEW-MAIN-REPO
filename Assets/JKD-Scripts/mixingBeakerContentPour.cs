using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class mixingBeakerContentPour : MonoBehaviour
{
    [SerializeField] ScoreMngr _ScoreMngr;
    [SerializeField] AudioMngr _AudioMngr;
    ParticleSystem mixingBeakerContPour;
    public float myangle = 60f;


    private bool mixingbeakercontWasted = false;
    private bool s2Chemwasted = false;
    private void Start() 
    {
        // get the component
        mixingBeakerContPour = GetComponent<ParticleSystem>();
        // Reset variables
        s2Chemwasted = false;
    }
    private void Update()
    {
        //This check if the player spills the content of the mixing beaker
        float angle = Vector3.Angle(Vector3.down, transform.forward);
        if (angle <= myangle && GameMngr.S2currentsteps >= 1)
        { 
            mixingBeakerContPour.Play();
        }
        else
        {
            mixingBeakerContPour.Stop();
        }

    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.CompareTag("table"))
        {
            Debug.Log("Particle collided with table");
            if(!s2Chemwasted)
            {
                s2Chemwasted = true;
                _ScoreMngr.Deductions("SpilledChem");
            }
        }
        if(other.CompareTag("floor"))
        {
            Debug.Log("Particle collided with floor");
            if(!s2Chemwasted)
            {
                s2Chemwasted = true;
                _ScoreMngr.Deductions("SpilledChem");
            }
        }
    }
}
