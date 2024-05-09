using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerMovementController : MonoBehaviour
{
    public ContinuousMoveProviderBase continuousMove;

    public void DisablePlayerMovement()
    {
        if (continuousMove)
        {
            continuousMove.enabled = false;
        }
    }

    public void EnablePlayerMovement()
    {
        if (continuousMove)
        {
            continuousMove.enabled = true;
        }
    }
}
