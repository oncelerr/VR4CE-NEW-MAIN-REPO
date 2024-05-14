using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuGameManager : MonoBehaviour
{
    public GameObject massR;
    public GameObject chemR;

    public bool isTutorialDone = false;
    public bool isMassRDone = false;
    public bool isAgreed = false;

    public GameObject startBTN;
    public GameObject agreeBTN;
    public GameObject termsCondition;
    public GameObject cartridges;

    void Update()
    {
        isTutorialDone = PlayerPrefs.GetInt("IsTutorialDone", 0) == 1;
        isMassRDone = PlayerPrefs.GetInt("IsMassRDone", 0) == 2;
        isAgreed = PlayerPrefs.GetInt("agreed", 0) == 4;
        if (isTutorialDone)
        {
            massR.SetActive(true);
        }
        if (isMassRDone)
        {
            chemR.SetActive(true);
        }
        if (isAgreed)
        {
            startBTN.SetActive(true);
            agreeBTN.SetActive(false);
            cartridges.SetActive(true);
            termsCondition.SetActive(false);
        }
    }
    public void ResetScene()
    {
        SceneManager.LoadScene("Menu");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
