using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public int scoring;
    public List<Image> img;

    public float universalScore = 100;
    public TextMeshProUGUI scoreText; // Reference to the UI text to display the score
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreMessage;

    private float startTime;

    private bool isGameFinished = false;

    public float totalTime;

    public GameObject reco1;
    public GameObject reco2;
    public GameObject reco3;
    public GameObject reco4;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioClip audioClip4;

    void Start()
    {
        // Record the start time when the scene starts
        startTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;

        if (!isGameFinished)
        {
            totalTime = (int)elapsedTime;
            Debug.Log(totalTime);
            totalTime = elapsedTime;
        } 
        else
        {
            Debug.Log(universalScore);
            UpdateScoreText();
            isGameFinished = false;
        }
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensures only one GameManager instance exists
        }
    }

    public void IncrementUniversalScore()
    {
        universalScore = 100 + universalScore;
        scoreText1.SetText(universalScore.ToString());
    }

    public void MinusUniversalScore()
    {
        universalScore = universalScore - scoring;
        scoreText1.SetText(universalScore.ToString());
        Debug.Log(universalScore);
    }

    public float GetUniversalScore()
    {
        return universalScore;
    }

    // Update UI text with the current score
    private void UpdateScoreText()
    {
        

        if (scoreText != null)
        {
            scoreText.text = universalScore.ToString();

            if (universalScore <= 250)
            {
                img[0].gameObject.SetActive(true);
                scoreMessage.text = "Failed!";
                reco1.SetActive(true);
                AudioSource.PlayClipAtPoint(audioClip1, transform.position);
            }
            else if (universalScore <= 500)
            {
                img[1].gameObject.SetActive(true);
                scoreMessage.text = "Good!";
                reco2.SetActive(true);
                AudioSource.PlayClipAtPoint(audioClip2, transform.position);
            }
            else if (universalScore <= 1000)
            {
                img[2].gameObject.SetActive(true);
                scoreMessage.text = "Great!";
                reco3.SetActive(true);
                AudioSource.PlayClipAtPoint(audioClip3, transform.position);
            }
            else if (universalScore >= 1500)
            {
                img[3].gameObject.SetActive(true);
                scoreMessage.text = "Excellent!";
                reco4.SetActive(true);
                AudioSource.PlayClipAtPoint(audioClip4, transform.position);
            }
        }
    }

    // Method to be called when the button is clicked (UI Button's OnClick event)
    public void OnButtonClick()
    {
        IncrementUniversalScore(); // Increment the score when the button is clicked
        Debug.Log(universalScore);
    }

    public void gameFinished()
    {
        isGameFinished = true;
    }

    public void MultiplyScore()
    {
        if (totalTime <= 120)
        {
            universalScore = universalScore * 4;
        } 
        else if (totalTime > 120 && totalTime < 240)
        {
            universalScore = (float)(universalScore * 3.5);
        }
        else if (totalTime > 240 && totalTime < 360)
        {
            universalScore = universalScore * 3;
        }
        else if (totalTime > 360 && totalTime < 480)
        {
            universalScore = (float)(universalScore * 2.5);
        }
        else if (totalTime > 480 && totalTime < 600)
        {
            universalScore = universalScore * 2;
        }
        else if (totalTime > 600 && totalTime < 720)
        {
            universalScore = (float)(universalScore * 1.5);
        }
        else
        {
            universalScore = universalScore * 1;
        }
    }
}
