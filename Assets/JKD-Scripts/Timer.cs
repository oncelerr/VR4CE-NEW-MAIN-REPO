using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CountDownTimerMesh;
    [SerializeField] TextMeshProUGUI CountUpTimerMesh;
    [SerializeField] TextMeshProUGUI timerLoopMesh;
    private Coroutine countdownCoroutine;
    public static float CDcurrentTime;
    public static float CUcurrentTime;
    public static float CUcurrentTime2;
    public static float CUcurrentTime3;
    public static float CUcurrentTime4;
    private bool isPaused;

    public float countDuration = 1f; // Duration for each count
    private float timer = 0f;
    public static int LoopCount = 7;
    private bool countingUp = true;
    public static bool isRunningLoop = false;
    
    private void Start() 
    {
        // Reset Variables
        isPaused = false;
        isRunningLoop = false;
        countingUp = true;
        LoopCount = 7;
        timer = 0f;
        countDuration = 1f;

        CDcurrentTime = 0f;
        CUcurrentTime = 0f;
        CUcurrentTime2 = 0f;
        CUcurrentTime3 = 0f;
        CUcurrentTime4 = 0f;
    }

    private void Update() 
    {
        LoopingTimer();
    }
    public void StartCountDownTimer(float _countdownTime)
    {
        CDcurrentTime = _countdownTime;
        isPaused = false;
        countdownCoroutine = StartCoroutine(StartCountdown());
        Debug.Log("TIME STARTED!");
    }

    // Countdown Timer
    public void PauseTimer()
    {
        if (countdownCoroutine != null)
        {
            isPaused = true;
            StopCoroutine(countdownCoroutine);
            Debug.Log("TIME PAUSED!");
        }
    }

    public void ResumeTimer()
    {
        if (isPaused)
        {
            isPaused = false;
            countdownCoroutine = StartCoroutine(StartCountdown());
            Debug.Log("TIME RESUMED!");
        }
    }

    public void StopTimer()
    {
        if (countdownCoroutine != null)
        {
            isPaused = false;
            StopCoroutine(countdownCoroutine);
            CDcurrentTime = 0f;
            Debug.Log("TIME STOPPED!");
        }
    }

    private IEnumerator StartCountdown()
    {
        while (CDcurrentTime >= 0)
        {
            CountDownTimerMesh.text = CDcurrentTime.ToString("F0");
            if (!isPaused)
            {
                yield return new WaitForSeconds(1f);
                CDcurrentTime--;
            }
            else
            {
                yield return null;
            }
        }
        Debug.Log("TIME IS UP!");
    }



    // Count Up Timer
    // Timer 1
    public void StartCountUpTimer(float startTime, float endTime)
    {
        CUcurrentTime = startTime;
        Coroutine timerCoroutine = StartCoroutine(UpdateUpTimer(endTime));
    }

    private IEnumerator UpdateUpTimer(float endTime)
    {
        float updateInterval = 1f;
        while (CUcurrentTime < endTime)
        {
            CUcurrentTime += updateInterval;
            CountUpTimerMesh.text = CUcurrentTime.ToString("F0");
            yield return new WaitForSeconds(updateInterval);
        }
    }

    // Timer 2
    public void StartCountUpTimer2(float startTime, float endTime)
    {
        CUcurrentTime2 = startTime;
        Coroutine timerCoroutine = StartCoroutine(UpdateUpTimer2(endTime));
    }

    private IEnumerator UpdateUpTimer2(float endTime)
    {
        float updateInterval = 1f;
        while (CUcurrentTime2 < endTime)
        {
            CUcurrentTime2 += updateInterval;
            // CountUpTimerMesh.text = CUcurrentTime2.ToString("F0");
            yield return new WaitForSeconds(updateInterval);
        }
    }

    // Timer 3
    public void StartCountUpTimer3(float startTime, float endTime)
    {
        CUcurrentTime3 = startTime;
        Coroutine timerCoroutine = StartCoroutine(UpdateUpTimer3(endTime));
    }

    private IEnumerator UpdateUpTimer3(float endTime)
    {
        float updateInterval = 1f;
        while (CUcurrentTime3 < endTime)
        {
            CUcurrentTime3 += updateInterval;
            // CountUpTimerMesh.text = CUcurrentTime2.ToString("F0");
            yield return new WaitForSeconds(updateInterval);
        }
    }

    // Timer 4
    public void StartCountUpTimer4(float startTime, float endTime)
    {
        CUcurrentTime4 = startTime;
        Coroutine timerCoroutine = StartCoroutine(UpdateUpTimer4(endTime));
    }

    private IEnumerator UpdateUpTimer4(float endTime)
    {
        float updateInterval = 1f;
        while (CUcurrentTime4 < endTime)
        {
            CUcurrentTime4 += updateInterval;
            // CountUpTimerMesh.text = CUcurrentTime2.ToString("F0");
            yield return new WaitForSeconds(updateInterval);
        }
    }

    // Looping Timer
    public void LoopingTimer()
    {
        if (!isRunningLoop)
            return;

        timer += Time.deltaTime;

        if (countingUp)
        {
            if (timer >= countDuration)
            {
                timer = 0f;
                LoopCount++;

                if (LoopCount > 9)
                {
                    LoopCount = 9;
                    countingUp = false;
                }
            }
        }
        else
        {
            if (timer >= countDuration)
            {
                timer = 0f;
                LoopCount--;

                if (LoopCount < 7)
                {
                    LoopCount = 7;
                    countingUp = true;
                }
            }
        }
        // Debug.Log("Count: " + LoopCount);
        timerLoopMesh.text = LoopCount.ToString("F0");
    }
}
