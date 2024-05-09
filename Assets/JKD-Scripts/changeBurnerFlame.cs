using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class changeBurnerFlame : MonoBehaviour
{
    public XRKnob knob;
    // [SerializeField] GameObject Air_Controller;
    public Color y1;
    public Color yb1;
    public Color yb2;
    public Color yb3;
    public Color yb4;
    public Color yb5;
    public Color yb6;
    public Color yb7;
    
    public static bool burnerFlameAchieved = false;

    private ParticleSystem particleSystem;
    
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        if (particleSystem == null)
        {
            Debug.LogError("Particle system component not found!");
        }
    }

    void Update()
    {
        // Debug.Log("The knob value is: "+knob.value);
        CurrentAirControl();
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     var main = particleSystem.main;
        //     main.startColor = new ParticleSystem.MinMaxGradient(newColor);
        // }
    }

    //This method refers to the adjustable air control of the burner
    public void CurrentAirControl()
    {
        //Initializations
        var main = particleSystem.main;
        // Quaternion rotation = Air_Controller.transform.rotation;
        // Vector3 eulerAngles = rotation.eulerAngles;

        // Convert the Euler angles to 1-12 real numbers
        // float z = eulerAngles.z / 30f;

        // Debug.Log("Rotation: "  + z);
        
        // if(knob.value >= 0.f && knob.value <= 0.356f)
        // {
        //     yb1 = Color.red;
        //     main.startColor = new ParticleSystem.MinMaxGradient(yb1); //75%
        // }
        if(knob.value >= 0.400f && knob.value <= 0.402f)
        {
            yb2 = Color.red;
            main.startColor = new ParticleSystem.MinMaxGradient(yb2);//80%
        }
        else if(knob.value >= 0.350f && knob.value <= 0.356f)
        {
            yb3 = Color.red;
            main.startColor = new ParticleSystem.MinMaxGradient(yb3);//90%
        }
        else if(knob.value >= 0.200f && knob.value <= 0.230f)
        {
            burnerFlameAchieved = true;
            yb4 = Color.blue;
            main.startColor = new ParticleSystem.MinMaxGradient(yb4); //100%
        }
        else if(knob.value >= 0.350f && knob.value <= 0.360f)
        {
            yb5 = Color.red;
            main.startColor = new ParticleSystem.MinMaxGradient(yb5);//90%
        }
        else if(knob.value >= 0.400f && knob.value <= 0.402f)
        {
            yb6 = Color.red;
            main.startColor = new ParticleSystem.MinMaxGradient(yb6);//80%
        }
        // else if(z >= 6f && z <= 6.3f)
        // {   
        //     yb7 = Color.red;
        //     main.startColor = new ParticleSystem.MinMaxGradient(yb7); //75%
        // }
        else
        {
            y1 = Color.yellow;
            main.startColor = new ParticleSystem.MinMaxGradient(y1); //Defaut state w/c is color yellow
        }

    }
}
