using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goBackToMainMenu : MonoBehaviour
{
    public string sceneName; // Name of the scene to transition to

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Transitioning to " + sceneName);
    }
}
