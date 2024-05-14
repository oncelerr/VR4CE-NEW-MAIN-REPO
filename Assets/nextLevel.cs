using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public void LoadOtherScene()
    {
        // Load the scene by its name
        SceneManager.LoadScene("Menu");
    }
}
