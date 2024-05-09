using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonClickTut : MonoBehaviour
{
    [Header("Main Menu Buttons")]
    public Button backToMenu;
    public Button proceedGame;

    void Start()
    {
        backToMenu.onClick.AddListener(BackToMenu);
        proceedGame.onClick.AddListener(ProceedGame);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0); // Load the scene with build index 0 (Menu scene)
    }
    public void ProceedGame()
    {
        SceneManager.LoadScene(2); // Load the scene with build index 2 (Game scene)
    }
}
