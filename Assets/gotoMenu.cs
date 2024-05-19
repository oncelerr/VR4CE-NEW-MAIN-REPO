using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoMenu : MonoBehaviour
{
    public SceneTransitionManager SceneTransitionManager;
    public void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
