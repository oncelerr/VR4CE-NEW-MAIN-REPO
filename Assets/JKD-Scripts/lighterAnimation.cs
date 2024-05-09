using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class lighterAnimation : MonoBehaviour
{
    [SerializeField] AudioMngr _AudioMngr;
    [SerializeField] BubbleGenerator _BubbleGenerator;
    [SerializeField] ParticleSystem lighterFire;
    [SerializeField] GameObject lightLid;
    public float speed = 0.1f;
    public Quaternion openLidRotation = Quaternion.Euler(0, 180f, 71.996f);
    public Quaternion closeLidRotation = Quaternion.Euler(0, 180f, 180f);
    public static bool FireIgnited = false;
    public static bool isLItHoldingLighter = false;
    public ParticleSystem fireInRHand;



    private void OnTriggerEnter(Collider other) 
    {
        // Combustion part
        if(other.gameObject.CompareTag("RightHandBubble") && BubbleGenerator.alreadyTakeBubbleinAnyHands)
        {
            // Cheking which hand contains the bubble
            if(BubbleGenerator.WhichHandhavetheBubbles == 2 && isLItHoldingLighter && !FireIgnited)
            {
                Debug.Log("It should fire now");
                FireIgnited = true;
                Sequence fire2Seq = DOTween.Sequence();
                fire2Seq.AppendCallback(() => fireInRHand.Play()); // Fire will play
                fire2Seq.AppendCallback(() => _BubbleGenerator.OutBubblePar());
                fire2Seq.AppendInterval(.5f);  // Delay of 1s
                fire2Seq.AppendCallback(() => TurnOffFire(fireInRHand, _BubbleGenerator.BubbleParticleinRHand)); 
                fire2Seq.Play();
                BubbleGenerator.alreadyStartedBubble = false;
                BubbleGenerator.alreadyTakeBubbleinAnyHands = false;
                FireIgnited = false;
                if (GameMngr.S1currentsteps == 5f)
                {
                    GameMngr.S1currentsteps = 6f;
                    vrRobot.currentStepExecuted = false;
                    Debug.Log("current step set to 6");
                }
                _AudioMngr.WhooseFireFX(true);
            }
        }
    }

   
    //This method will open the Lid of the Lighter
    public void OpenLid()
    {
        lightLid.transform.localEulerAngles = new Vector3(0, 180f, 180f);

        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(.3f);
        mySequence.Append(lightLid.transform.DORotateQuaternion(openLidRotation, speed).SetEase(Ease.Linear));
        mySequence.OnComplete(() => {
            lighterFire.Play(); // lighter fire effect will play after the lid has opened
            lightLid.transform.localEulerAngles = new Vector3(0, 180f, 71.996f);
        });
        mySequence.Play();
        _AudioMngr.LighterFX(true);
    }

    //This method will close the Lid of the Lighter
    public void CloseLid()
    {
        lighterFire.Stop();
        lightLid.transform.localEulerAngles = new Vector3(0, 180f, 71.996f);
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(.3f);
        mySequence.Append(lightLid.transform.DORotateQuaternion(closeLidRotation, speed).SetEase(Ease.Linear));
        mySequence.OnComplete(() => {
            lightLid.transform.localEulerAngles = new Vector3(0, 180f, 180f);
            lighterFire.Stop();
        });
        mySequence.Play();
        _AudioMngr.LighterFX(false);
    }
    public void HoldingLighter(bool stat)
    {
        isLItHoldingLighter = stat;
    }

    private void TurnOffFire(ParticleSystem fire, ParticleSystem bubble)
    {
        bubble.Stop();
        fire.Stop();
        _AudioMngr.WhooseFireFX(false);
        // fireStat = false;
    }
}
