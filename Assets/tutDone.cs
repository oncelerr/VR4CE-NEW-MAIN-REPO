using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutDone : MonoBehaviour
{
    public void tutaDone()
    {
        // Set PlayerPrefs to indicate tutorial is done
        PlayerPrefs.SetInt("IsTutorialDone", 1);
        PlayerPrefs.Save();
    }
}
