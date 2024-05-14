using DG.Tweening.Core.Easing;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static PlaySteps;

public class triggerZoneManager : MonoBehaviour
{
    public GameManager gamemanager;

    public rightPlateTrigger rightPlateTriggerScript;
    public leftPlateTrigger leftPlateTriggerScript;
    public PlaySteps playStepsScript;
    public AudioClip audioClip;
    public AudioClip audioClip1;

    private bool isMoving = false;
    private float duration = 0.5f;
    private int questionNumber = 1;
    private bool isBalanced = false;

    public void firstQuestion()
    {
        GameObject sphere1 = GameObject.FindGameObjectWithTag("sphere1");
        GameObject sphere2 = GameObject.FindGameObjectWithTag("sphere2");

        if(rightPlateTriggerScript.rightPlateWeight == leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
        }
        if(rightPlateTriggerScript.rightPlateWeight < leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.331f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.427f, -5.216f))); 
        }
        if (rightPlateTriggerScript.rightPlateWeight > leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.427f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.331f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight == 8 && leftPlateTriggerScript.leftPlateWeight == 8)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
            isBalanced = true;
        }

        Debug.Log(rightPlateTriggerScript.rightPlateWeight);
        Debug.Log(leftPlateTriggerScript.leftPlateWeight);
    }
    public void secondQuestion()
    {
        GameObject sphere1 = GameObject.FindGameObjectWithTag("sphere1");
        GameObject sphere2 = GameObject.FindGameObjectWithTag("sphere2");

        if (rightPlateTriggerScript.rightPlateWeight == leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight < leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.331f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.427f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight > leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.427f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.331f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight == 8 && leftPlateTriggerScript.leftPlateWeight == 8)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
            isBalanced = true;
        }

        Debug.Log(rightPlateTriggerScript.rightPlateWeight);
        Debug.Log(leftPlateTriggerScript.leftPlateWeight);
    }

    public void thirdQuestion()
    {
        GameObject sphere1 = GameObject.FindGameObjectWithTag("sphere1");
        GameObject sphere2 = GameObject.FindGameObjectWithTag("sphere2");

        if (rightPlateTriggerScript.rightPlateWeight == leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight < leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.331f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.427f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight > leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.427f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.331f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight == 10 && leftPlateTriggerScript.leftPlateWeight == 10)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
            isBalanced = true;
        }

        Debug.Log(rightPlateTriggerScript.rightPlateWeight);
        Debug.Log(leftPlateTriggerScript.leftPlateWeight);
    }

    public void fourthQuestion()
    {
        GameObject sphere1 = GameObject.FindGameObjectWithTag("sphere1");
        GameObject sphere2 = GameObject.FindGameObjectWithTag("sphere2");

        if (rightPlateTriggerScript.rightPlateWeight == leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight < leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.331f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.427f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight > leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.427f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.331f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight == 36 && leftPlateTriggerScript.leftPlateWeight == 36)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
            isBalanced = true;
        }

        Debug.Log(rightPlateTriggerScript.rightPlateWeight);
        Debug.Log(leftPlateTriggerScript.leftPlateWeight);
    }
    public void fifthQuestion()
    {
        GameObject sphere1 = GameObject.FindGameObjectWithTag("sphere1");
        GameObject sphere2 = GameObject.FindGameObjectWithTag("sphere2");

        if (rightPlateTriggerScript.rightPlateWeight == leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight < leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.331f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.427f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight > leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.427f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.331f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight == 23 && leftPlateTriggerScript.leftPlateWeight == 23)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
            isBalanced = true;
        }

        Debug.Log(rightPlateTriggerScript.rightPlateWeight);
        Debug.Log(leftPlateTriggerScript.leftPlateWeight);
    }
    public void sixthQuestion()
    {
        GameObject sphere1 = GameObject.FindGameObjectWithTag("sphere1");
        GameObject sphere2 = GameObject.FindGameObjectWithTag("sphere2");

        if (rightPlateTriggerScript.rightPlateWeight == leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight < leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.331f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.427f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight > leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.427f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.331f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight == 28 && leftPlateTriggerScript.leftPlateWeight == 28)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
            isBalanced = true;
        }

        Debug.Log(rightPlateTriggerScript.rightPlateWeight);
        Debug.Log(leftPlateTriggerScript.leftPlateWeight);
    }
    public void seventhQuestion()
    {
        GameObject sphere1 = GameObject.FindGameObjectWithTag("sphere1");
        GameObject sphere2 = GameObject.FindGameObjectWithTag("sphere2");

        if (rightPlateTriggerScript.rightPlateWeight == leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight < leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.331f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.427f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight > leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.427f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.331f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight == 58 && leftPlateTriggerScript.leftPlateWeight == 58)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
            isBalanced = true;
        }

        Debug.Log(rightPlateTriggerScript.rightPlateWeight);
        Debug.Log(leftPlateTriggerScript.leftPlateWeight);
    }
    public void eighthQuestion()
    {
        GameObject sphere1 = GameObject.FindGameObjectWithTag("sphere1");
        GameObject sphere2 = GameObject.FindGameObjectWithTag("sphere2");

        if (rightPlateTriggerScript.rightPlateWeight == leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight < leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.331f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.427f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight > leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.427f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.331f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight == 35 && leftPlateTriggerScript.leftPlateWeight == 35)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
            isBalanced = true;
        }

        Debug.Log(rightPlateTriggerScript.rightPlateWeight);
        Debug.Log(leftPlateTriggerScript.leftPlateWeight);
    }
    public void ninthQuestion()
    {
        GameObject sphere1 = GameObject.FindGameObjectWithTag("sphere1");
        GameObject sphere2 = GameObject.FindGameObjectWithTag("sphere2");

        if (rightPlateTriggerScript.rightPlateWeight == leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight < leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.331f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.427f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight > leftPlateTriggerScript.leftPlateWeight)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.427f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.331f, -5.216f)));
        }
        if (rightPlateTriggerScript.rightPlateWeight == 52 && leftPlateTriggerScript.leftPlateWeight == 52)
        {
            StartCoroutine(MoveObjectSmoothly(sphere1, sphere1.transform.position, new Vector3(3.25300002f, 1.384f, -5.216f)));
            StartCoroutine(MoveObjectSmoothly(sphere2, sphere2.transform.position, new Vector3(2.753f, 1.384f, -5.216f)));
            isBalanced = true;
        }

        Debug.Log(rightPlateTriggerScript.rightPlateWeight);
        Debug.Log(leftPlateTriggerScript.leftPlateWeight);
    }

    public void check()
    {
        Debug.Log("Pressed");
        if (isBalanced)
        {
            Debug.Log("Balanced");
            rightPlateTriggerScript.rightPlateWeight = 0;
            leftPlateTriggerScript.leftPlateWeight = 0;
            switch (questionNumber)
            {
                case 1:
                    playStepsScript.PlayStepIndex(10);
                    gamemanager.IncrementUniversalScore();
                    break;
                case 2:
                    playStepsScript.PlayStepIndex(11);
                    gamemanager.IncrementUniversalScore();
                    break;
                case 3:
                    playStepsScript.PlayStepIndex(12);
                    gamemanager.IncrementUniversalScore();
                    break;
                case 4:
                    playStepsScript.PlayStepIndex(13);
                    gamemanager.IncrementUniversalScore();
                    break;
                case 5:
                    playStepsScript.PlayStepIndex(14);
                    gamemanager.IncrementUniversalScore();
                    break;
                case 6:
                    playStepsScript.PlayStepIndex(15);
                    gamemanager.IncrementUniversalScore();
                    break;
                case 7:
                    playStepsScript.PlayStepIndex(16);
                    gamemanager.IncrementUniversalScore();
                    break;
                case 8:
                    playStepsScript.PlayStepIndex(17);
                    gamemanager.IncrementUniversalScore();
                    break;
                case 9:
                    playStepsScript.PlayStepIndex(18);
                    gamemanager.IncrementUniversalScore();
                    break;
            }
            questionNumber++;
            isBalanced = false;
        }
        else
        {
            if(rightPlateTriggerScript.rightPlateWeight < leftPlateTriggerScript.leftPlateWeight)
            {
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
                gamemanager.MinusUniversalScore();
            }
            if(rightPlateTriggerScript.rightPlateWeight > leftPlateTriggerScript.leftPlateWeight)
            {
                AudioSource.PlayClipAtPoint(audioClip1, transform.position);
                gamemanager.MinusUniversalScore();
            }
        }
    }

    private IEnumerator MoveObjectSmoothly(GameObject obj, Vector3 startPosition, Vector3 targetPosition)
    {
        isMoving = true;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            obj.transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = targetPosition; // Ensure the object reaches the exact target position
        isMoving = false;
    }
}