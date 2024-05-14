using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class massRDone : MonoBehaviour
{
    public void massDone()
    {
        // Set PlayerPrefs to indicate tutorial is done
        PlayerPrefs.SetInt("IsMassRDone", 2);
        PlayerPrefs.Save();
    }
}
