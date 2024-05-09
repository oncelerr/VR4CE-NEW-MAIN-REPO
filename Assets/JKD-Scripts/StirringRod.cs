using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StirringRod : MonoBehaviour
{
    public static bool _isHoldingStirrRod;

    private void Start() 
    {
        _isHoldingStirrRod = false;
    }

    public void HoldingStirrRod(bool isHoldingStirrRod)
    {
        if(isHoldingStirrRod)
        {
            _isHoldingStirrRod = true;
        }
        else
        {
            _isHoldingStirrRod = false;
        }
    }
}
