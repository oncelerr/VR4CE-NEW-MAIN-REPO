using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s3FerrousTubeContent : MonoBehaviour
{
    [SerializeField] ScoreMngr _ScoreMngr;
    public ParticleSystem[] ferrousSulfatePour;

    // ferroues content value
    public static float ferrousTubeSulfateAmount;
    public float MyAngle;
    private bool spilledPlayed = false;

    void Start()
    {
        // Reset variables
        spilledPlayed = false;
        ferrousTubeSulfateAmount = 0.30f;
    }

    void Update()
    {
        ferrousSulfatePour[s3TestTubeContent.whichtestubeisHolding] = GetComponent<ParticleSystem>();
        float angle = Vector3.Angle(Vector3.down, transform.forward);
        if (angle <= MyAngle)
        {
            ferrousSulfatePour[s3TestTubeContent.whichtestubeisHolding].Play();
        }
        else
        {
            ferrousSulfatePour[s3TestTubeContent.whichtestubeisHolding].Stop();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("table"))
        {
            if(!spilledPlayed)
            {
                spilledPlayed = true;
                _ScoreMngr.Deductions("SpilledChem");
            }
            if(ferrousTubeSulfateAmount > 0.30f)
            {
                ferrousTubeSulfateAmount -= 0.01f;
            }   
        }
    }
}
