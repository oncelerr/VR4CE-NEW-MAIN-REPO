using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s3FerrousContent : MonoBehaviour
{
    public GameObject _FerrousContentObj;
    public ParticleSystem ferrousSulfatePour;
    // ferroues content value
    public static float ferrousSulfateAmount = 0.30f;
    public float MyAngle;
    // private bool success = false;
    // private bool wasted = false;
    private Material material;
    private bool isHoldingFerrousjar = false;
    private bool alreadyCheckTransferState = false;

    void Start()
    {
        ferrousSulfatePour = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        float angle = Vector3.Angle(Vector3.down, transform.forward);
        if (angle <= MyAngle)
        {
            ferrousSulfatePour.Play();
        }
        else
        {
            ferrousSulfatePour.Stop();
        }
        if(s3TestTubeContent.s3testtubeAmount >= 0.5f)
        {
            ferrousSulfatePour.Stop();
            _FerrousContentObj.SetActive(false);
        }
        
        UpdateFerrousContent();
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("testtube"))
        {
            // Debug.Log("Colliding with mixing beaker");
            // Check niya if the empty beaker ay nareach na yung amount of the ferrous
            if(s3TestTubeContent.s3testtubeAmount < 0.51f) // Set the threshold 
            {
                // Dito iicrement niya yung value nung sa empty beaker para kunwari nafifill yung beaker
                s3TestTubeContent.s3testtubeAmount += 0.01f;
                ferrousSulfateAmount -= 0.01f;
            }
        }
        else
        {
            ferrousSulfateAmount -= 0.01f;
        }
    }
    private void UpdateFerrousContent() 
    {
        if(GameMngr.CurrentLevelIndex == 3 && isHoldingFerrousjar)
        {
            // Get the Renderer component of the GameObject
            Renderer ferrousRenderer = _FerrousContentObj.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = ferrousRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");

                // Equate to static variable na connected sa beaker
                fillValue = ferrousSulfateAmount;

                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);

                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);

                // Debug.Log("ferrous Current Fill Value: " + fillValue);
            }
            else
            {
                Debug.LogError("Ferrous Material does not have a _Fill property");
            }
        }
    }
    public void isHoldingFerrousJar(bool State)
    {
        if(State)
        {
            isHoldingFerrousjar = true;
        }
        else
        {
            isHoldingFerrousjar = false;
        }
    }

    // This method checks if the ferrous content is spilled and didn`t transfer correctly to the test tube
    private void CheckIfWasted()
    {
        if(ferrousSulfateAmount <= 0f && s3TestTubeContent.s3testtubeAmount == 0f && !alreadyCheckTransferState) 
        {
            alreadyCheckTransferState = true;
            
        }
    }
}
