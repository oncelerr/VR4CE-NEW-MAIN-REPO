using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMngr : MonoBehaviour
{
    [SerializeField] Slider[] _progressBar;
    public static float currentProgress = 0f;
    public static float currentProgress2 = 0f;
    public static float currentProgress3 = 0f;
    public static float currentProgress4 = 0f;
    public static float currentProgress5 = 0f;
 
    private void Start() 
    {
        _progressBar[1].value = 0f;
        _progressBar[2].value = 0f;
        _progressBar[3].value = 0f;
        _progressBar[4].value = 0f;
        _progressBar[5].value = 0f;
    }
    private void Update() 
    {
        if(GameMngr.CurrentLevelIndex == 1)
        {
            _progressBar[1].value = (currentProgress * .01f);
        }
        else if(GameMngr.CurrentLevelIndex == 2)
        {
            _progressBar[2].value = (currentProgress2 * .01f);
        }
        else if(GameMngr.CurrentLevelIndex == 3)
        {
            _progressBar[3].value = (currentProgress3 * .01f);
        }
        else if(GameMngr.CurrentLevelIndex == 4)
        {
            _progressBar[4].value = (currentProgress4 * .01f);
        }
        else if(GameMngr.CurrentLevelIndex == 5)
        {
            _progressBar[5].value = (currentProgress5 * .01f);
        }
    }
}
