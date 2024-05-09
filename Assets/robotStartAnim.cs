using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotStartAnim : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component.

    public void StartAnimation()
    {
        // Trigger the animation by setting a parameter in the Animator controller.
        animator.SetTrigger("StartAnimation");
    }
}
