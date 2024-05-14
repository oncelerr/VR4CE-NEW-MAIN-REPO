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
    public bool isChemRDone = false;
    public bool isAgree = false;

    public GameObject startBTN;
    public GameObject agreeBTN;
    public GameObject cartridges;
    public GameObject termsAndConditions;

    void Update()
    {
        isTutorialDone = PlayerPrefs.GetInt("IsTutorialDone", 0) == 1;
        isMassRDone = PlayerPrefs.GetInt("IsMassRDone", 0) == 2;
        isAgree = PlayerPrefs.GetInt("isAgree", 0) == 4;
        if (isTutorialDone)
        {
            massR.SetActive(true);
        }
        if (isMassRDone)
        {
            chemR.SetActive(true);
        }
        if (isAgree)
        {
            startBTN.SetActive(true);
            agreeBTN.SetActive(false);
            cartridges.SetActive(true);
            termsAndConditions.SetActive(false);
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene("Menu");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        isAgree = false;
}
}
