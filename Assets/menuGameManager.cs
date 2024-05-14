using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuGameManager : MonoBehaviour
{
    public GameObject massR;
    public GameObject chemR;

    public bool isTutorialDone = false;
    public bool isMassRDone = false;

    void Update()
    {
        isTutorialDone = PlayerPrefs.GetInt("IsTutorialDone", 0) == 1;
        isMassRDone = PlayerPrefs.GetInt("IsMassRDone", 0) == 2;
        if (isTutorialDone)
        {
            massR.SetActive(true);
        }
        if (isMassRDone)
        {
            chemR.SetActive(true);
        }
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
