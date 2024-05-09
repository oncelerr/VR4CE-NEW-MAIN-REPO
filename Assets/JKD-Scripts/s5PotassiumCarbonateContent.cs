using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s5PotassiumCarbonateContent : MonoBehaviour
{
    public GameObject _PotassiumCarbonateContentObj;
    public ParticleSystem _PotassiumCarbonatePour;
    public Vector3 _35DegreeSideParticle;
    public Vector3 _155DegreeSideParticle;
    // ferroues content value
    public static float _PotassiumCarbonateAmount = 0.30f;
    public float MyAngle1;
    public float MyAngle2;
    // private bool success = false;
    // private bool wasted = false;
    private Material material;
    private bool isHoldingPotassiumCjar = false;
    private bool alreadyCheckTransferState = false;

    void Start()
    {
        _PotassiumCarbonatePour = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        // These code checks if the player will pour the chemical in diff. side
        float angle = Vector3.Angle(Vector3.down, transform.forward);
        float angle2 = Vector3.Angle(Vector3.up, transform.forward);
        if (angle <= MyAngle1)
        {
            _PotassiumCarbonatePour.Play();
            _PotassiumCarbonatePour.transform.localPosition = _35DegreeSideParticle;
        }
        else if(angle2 <= MyAngle2)
        {
            _PotassiumCarbonatePour.Play();
            _PotassiumCarbonatePour.transform.localPosition = _155DegreeSideParticle;
        }
        else
        {
            _PotassiumCarbonatePour.Stop();
        }
        if(s5TestTubeContent.s5testtubeAmountPC >= 0.8f)
        {
            _PotassiumCarbonatePour.Stop();
            _PotassiumCarbonateContentObj.SetActive(false);
        }
        
        UpdatePotassiumCarbonateContent();
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("testtube"))
        {
            // Debug.Log("Colliding with mixing beaker");
            // Check niya if the empty beaker ay nareach na yung amount of the silver nitrate
            if(s5TestTubeContent.s5testtubeAmountPC < 0.8f) // Set the threshold 
            {
                // Dito iicrement niya yung value nung sa empty beaker para kunwari nafifill yung beaker
                s5TestTubeContent.s5testtubeAmountPC += 0.01f;
                _PotassiumCarbonateAmount -= 0.01f;
            }
        }
        // else
        // {
        //     _PotassiumCarbonateAmount -= 0.01f;
        // }
    }
    private void UpdatePotassiumCarbonateContent() 
    {
        if(GameMngr.CurrentLevelIndex == 5 && isHoldingPotassiumCjar)
        {
            // Get the Renderer component of the GameObject
            Renderer ferrousRenderer = _PotassiumCarbonateContentObj.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = ferrousRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");

                // Equate to static variable na connected sa beaker
                fillValue = _PotassiumCarbonateAmount;

                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);

                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);
            }
        }
    }
    public void isHoldingPotassiumCJar(bool State)
    {
        if(State)
        {
            isHoldingPotassiumCjar = true;
        }
        else
        {
            isHoldingPotassiumCjar = false;
        }
    }

    // This method checks if the ferrous content is spilled and didn`t transfer correctly to the test tube
    private void CheckIfWasted()
    {
        if(_PotassiumCarbonateAmount <= 0f && s5TestTubeContent.s5testtubeAmount == 0f && !alreadyCheckTransferState) 
        {
            alreadyCheckTransferState = true;
            
        }
    }
}
