using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    
    [SerializeField] DataMngr _DataMngr;

    public void RestartScene()
    {
        // Get the index of the currently active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Reload the scene by its index
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadScene(int levelIndex)
    {
        StartCoroutine(LoadSceneAsynchronously(levelIndex));
    }

    IEnumerator LoadSceneAsynchronously(int levelIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);
        // loadingScreen.SetActive(true);
        // while (!operation.isDone)
        // {
        //     loadingBar.value = operation.progress;
        //     // Debug.Log(operation.progress);
        //     yield return null;
        // }
        yield return null;
    }
}
