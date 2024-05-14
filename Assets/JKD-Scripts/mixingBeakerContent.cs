using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class mixingBeakerContent : MonoBehaviour
{
    [SerializeField] ScoreMngr _ScoreMngr;
    [SerializeField] AudioMngr _AudioMngr;
    public ParticleSystem mixingBeakerContPour;
    public GameObject mixingBeakerContentObj;
    public GameObject aluminumContent;
    public static float iodineValue = 0f;
    public static float aluminumValue = 0f;

    // Variables for checking if the powder is already transfer
    public static bool iodineTransferSuccess;
    public static bool aluminumTransferSuccess;

    // Variable for checking if the mixing beaker is spilling
    public static bool isMixingBeakerCurrentlySpilling;

    private bool mixingbeakercontWasted = false;
    private void Start() 
    {
        iodineTransferSuccess = false;
        aluminumTransferSuccess = false;
        isMixingBeakerCurrentlySpilling = false;
    }
    private void Update()
    {
        FillBeaker(iodineValue, mixingBeakerContentObj, mixingBeaker.isItHoldingIodineBeaker);
        FillBeaker(aluminumValue, aluminumContent, mixingBeaker.isItHoldingAluminumBeaker);
        
        if(!mixingbeakercontWasted && iodineTransferSuccess && aluminumTransferSuccess)
        {
            mixingbeakercontWasted = true;
            Sequence sequence = DOTween.Sequence();
            sequence.AppendCallback(() => _ScoreMngr.Deductions("SpilledChem"));
            sequence.AppendInterval(_AudioMngr.DeductionClips[1].length); // Delay
            sequence.AppendCallback(() => _ScoreMngr.GameOver());
            sequence.Play();
        }
        //This check if the player spills the content of the mixing beaker
        float angle = Vector3.Angle(Vector3.down, transform.forward);
        if (angle <= -60f && (GameMngr.S2currentsteps == 1 || GameMngr.S2currentsteps == 2 || GameMngr.S2currentsteps == 3))
        { 
            if(aluminumValue != 0 || iodineValue != 0) 
            {
                mixingBeakerContPour.Play();
                isMixingBeakerCurrentlySpilling = true;
            }
            
        }
        else
        {
            mixingBeakerContPour.Stop();
            isMixingBeakerCurrentlySpilling = false;
        }

    }

    private void OnParticleCollision(GameObject other)
    {
        if(aluminumValue > 0 && (iodineTransferSuccess || aluminumTransferSuccess)) 
        {
            aluminumValue -= 0.01f;
            _ScoreMngr.Deductions("SpilledChem");
        }
        if(aluminumValue <= 0 && iodineValue > 0) 
        {
            iodineValue -= 0.01f;
            _ScoreMngr.Deductions("SpilledChem");
        }
    }

    public void FillBeaker(float Liquid, GameObject content, bool beakerHolding)
    {
        if(GameMngr.CurrentLevelIndex == 2 && beakerHolding)
        {
            // Get the Renderer component of the GameObject
            Renderer iodineRenderer = content.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = iodineRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");

                // Equate to static variable na connected sa beaker
                fillValue = Liquid;

                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);

                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);

                // Debug.Log("Current Fill Value: " + fillValue);
            }
            else
            {
                Debug.LogError("Material does not have a _Fill property");
            }
        }
    }
}
