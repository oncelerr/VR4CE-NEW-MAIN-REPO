using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartMass : MonoBehaviour
{
    public void RestartScene()
    {
        // Get the current scene's index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the current scene again by its index
        SceneManager.LoadScene(currentSceneIndex);

        GameManager.universalScore = 0;
    }
}
