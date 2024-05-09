using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s5SilverNitrateContent : MonoBehaviour
{
    public GameObject _SilverNitrateContentObj;
    public ParticleSystem _SilverNitratePour;
    public Vector3 _35DegreeSideParticle;
    public Vector3 _155DegreeSideParticle;
    // ferroues content value
    public static float _SilverNitrateAmount = 0.30f;
    public float MyAngle1;
    public float MyAngle2;
    // private bool success = false;
    // private bool wasted = false;
    private Material material;
    private bool isHoldingSilverNjar = false;
    private bool alreadyCheckTransferState = false;

    void Start()
    {
        _SilverNitratePour = GetComponent<ParticleSystem>();
    }
    void Update()
    {
        // These code checks if the player will pour the chemical in diff. side
        float angle = Vector3.Angle(Vector3.down, transform.forward);
        float angle2 = Vector3.Angle(Vector3.up, transform.forward);
        if (angle <= MyAngle1)
        {
            _SilverNitratePour.Play();
            _SilverNitratePour.transform.localPosition = _35DegreeSideParticle;
        }
        else if(angle2 <= MyAngle2)
        {
            _SilverNitratePour.Play();
            _SilverNitratePour.transform.localPosition = _155DegreeSideParticle;
        }
        else
        {
            _SilverNitratePour.Stop();
        }
        if(s5TestTubeContent.s5testtubeAmount >= 0.5f)
        {
            _SilverNitratePour.Stop();
            _SilverNitrateContentObj.SetActive(false);
        }
        
        UpdateSilverNitrateContent();
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("testtube"))
        {
            // Debug.Log("Colliding with mixing beaker");
            // Check niya if the empty beaker ay nareach na yung amount of the silver nitrate
            if(s5TestTubeContent.s5testtubeAmount < 0.51f) // Set the threshold 
            {
                // Dito iicrement niya yung value nung sa empty beaker para kunwari nafifill yung beaker
                s5TestTubeContent.s5testtubeAmount += 0.01f;
                _SilverNitrateAmount -= 0.01f;
            }
        }
        // else
        // {
        //     _SilverNitrateAmount -= 0.01f;
        // }
    }
    private void UpdateSilverNitrateContent() 
    {
        if(GameMngr.CurrentLevelIndex == 5 && isHoldingSilverNjar)
        {
            // Get the Renderer component of the GameObject
            Renderer ferrousRenderer = _SilverNitrateContentObj.GetComponent<Renderer>();

            // Get the material of the Renderer
            Material material = ferrousRenderer.material;

            // Check if the material has a "_Fill" property
            if (material.HasProperty("_Fill"))
            {
                // Get the current fill value from the material
                float fillValue = material.GetFloat("_Fill");

                // Equate to static variable na connected sa beaker
                fillValue = _SilverNitrateAmount;

                // Clamp the fill value to stay within the range 0 to 1
                fillValue = Mathf.Clamp01(fillValue);

                // Set the fill value in the material
                material.SetFloat("_Fill", fillValue);
            }
        }
    }
    public void isHoldingSilverNJar(bool State)
    {
        if(State)
        {
            isHoldingSilverNjar = true;
        }
        else
        {
            isHoldingSilverNjar = false;
        }
    }

    // This method checks if the ferrous content is spilled and didn`t transfer correctly to the test tube
    private void CheckIfWasted()
    {
        if(_SilverNitrateAmount <= 0f && s5TestTubeContent.s5testtubeAmount == 0f && !alreadyCheckTransferState) 
        {
            alreadyCheckTransferState = true;
        }
    }
}
