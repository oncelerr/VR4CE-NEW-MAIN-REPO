using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timescript : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private float timer = 0f;
    private bool isTimerRunning = true;
    void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }
}
