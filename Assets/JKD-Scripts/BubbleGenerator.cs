using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGenerator : MonoBehaviour
{
    public ParticleSystem BubbleParticle;
    public ParticleSystem BubbleParticleinLHand;
    public ParticleSystem BubbleParticleinRHand;
    float InsimSpeed = 1f;
    float OutsimSpeed = 0.1f;
    public static bool alreadyStartedBubble = false;
    bool holdingHose = false;
    public static bool alreadyTakeBubbleinAnyHands = false;
    public static int WhichHandhavetheBubbles = 0;  //1 for left, 2 for right
    // bool static   = false;

    private void OnTriggerEnter(Collider other) 
    {
        // Values checking
        Debug.Log("Value of alreadyStartedBubble = "+alreadyStartedBubble);
        Debug.Log("Value of RinseWithWater.alreadyRinseWWater = "+RinseWithWater.alreadyRinseWWater);
        Debug.Log("Value of alreadyTakeBubbleinAnyHands = "+alreadyTakeBubbleinAnyHands);
        Debug.Log("Value of HandsMnger.HodingHoseNozzle = "+HandsMnger.HodingHoseNozzle);


        if(other.gameObject.CompareTag("hoseNozzle") && !alreadyStartedBubble)
        {
            alreadyStartedBubble = true;
            BubbleParticle.Play();
            if (GameMngr.S1currentsteps == 3f)
            {
                GameMngr.S1currentsteps = 4f;
                vrRobot.currentStepExecuted = false;
            }
        }

        // Taking the bubbles into player`s Left hand
        if(other.gameObject.CompareTag("Human") && RinseWithWater.alreadyRinseWWater && !HandsMnger.HodingHoseNozzle && alreadyStartedBubble && !alreadyTakeBubbleinAnyHands)
        {
            alreadyTakeBubbleinAnyHands = true;
            BubbleParticleinLHand.Play();
            var main = BubbleParticleinLHand.main;
            main.simulationSpeed = InsimSpeed;
            BubbleParticle.Stop();
            WhichHandhavetheBubbles = 1;
            Debug.Log("Already have bubbles in Left hand");
        }

        // Taking the bubbles into player`s Right hand
        if(other.gameObject.CompareTag("Right Hand") && RinseWithWater.alreadyRinseWWater && !HandsMnger.HodingHoseNozzle && alreadyStartedBubble && !alreadyTakeBubbleinAnyHands)
        {
            alreadyTakeBubbleinAnyHands = true;
            BubbleParticleinRHand.Play();
            var main = BubbleParticleinRHand.main;
            main.simulationSpeed = InsimSpeed;
            BubbleParticle.Stop();
            WhichHandhavetheBubbles = 2;
            if (GameMngr.S1currentsteps == 4f)
            {
                GameMngr.S1currentsteps = 5f;
                vrRobot.currentStepExecuted = false;
            }
            Debug.Log("Already have bubbles in Right hand");
        }
    }
    private void OnTriggerStay(Collider other) 
    {
        if(other.gameObject.CompareTag("hoseNozzle"))
        {
            // BubbleParticle.Play();
            var main = BubbleParticle.main;
            main.simulationSpeed = InsimSpeed;
        }
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("hoseNozzle"))
        {
            var main = BubbleParticle.main;
            main.simulationSpeed = OutsimSpeed;
        }

        if(other.gameObject.CompareTag("Human") && !HandsMnger.HodingHoseNozzle && alreadyStartedBubble)
        {
            var main = BubbleParticleinLHand.main;
            main.simulationSpeed = OutsimSpeed;
        }

        if(other.gameObject.CompareTag("Right Hand") && !HandsMnger.HodingHoseNozzle && alreadyStartedBubble)
        {
            var main = BubbleParticleinRHand.main;
            main.simulationSpeed = OutsimSpeed;
        }

        
    }
    public void OutBubblePar()
    {
        var main = BubbleParticleinRHand.main;
        main.simulationSpeed = 4f;
    }
}
