using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class ScoreMngr : MonoBehaviour
{
    public HandsMnger _HandsMnger;
    public AudioMngr _AudioMngr;
    public GameObject ScoreMenuObj;
    public GameObject[] Stars;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Points;
    public TextMeshProUGUI Points2;
    public TextMeshProUGUI Points3;
    public TextMeshProUGUI Points4;
    public TextMeshProUGUI Points5;
    public TextMeshProUGUI ScoreTimerMesh;
    public TextMeshProUGUI ScoreTimerMesh2;
    public TextMeshProUGUI ScoreTimerMesh3;
    public TextMeshProUGUI ScoreTimerMesh4;
    public TextMeshProUGUI ScoreTimerMesh5;
    public TextMeshProUGUI Performance;
    public TextMeshProUGUI NextBtnText;
    public GameObject NextBtnObj;
    public Button NextBtn;

    public Color RedBtn = Color.red;
    public Color GreenBtn = Color.green;
    public Vector3[] ScoreboardPosition;
    public Transform ScoreBoardTransform;
    public Transform PlayerTransform;

    public static float TotalScore;
    public static float STcurrentTime;

    private Coroutine ScoretimerCoroutine;
    private bool GameOverAlreadyPlayed;

    private void Start() 
    {
        // Initialize static variables
        TotalScore = 0f;
        STcurrentTime = 0f;
        GameOverAlreadyPlayed = false;

        ScoreMenuObj.SetActive(false);
        switch (GameMngr.CurrentLevelIndex)
        {
            case 1:
                ScoreBoardTransform.DOMove(ScoreboardPosition[GameMngr.CurrentLevelIndex], 0.5f);
                break;
            case 2:
                ScoreBoardTransform.DOMove(ScoreboardPosition[GameMngr.CurrentLevelIndex], 0.5f);
                break;
            case 3:
                ScoreBoardTransform.DOMove(ScoreboardPosition[GameMngr.CurrentLevelIndex], 0.5f);
                break;
            case 4:
                ScoreBoardTransform.DOMove(ScoreboardPosition[GameMngr.CurrentLevelIndex], 0.5f);
                break;
            case 5:
                ScoreBoardTransform.DOMove(ScoreboardPosition[GameMngr.CurrentLevelIndex], 0.5f);
                break;
            default:
                Debug.LogError("Invalid level index!");
                break;
        }
    } 

    private void Update() 
    {
        Vector3 direction = PlayerTransform.position - ScoreBoardTransform.position;
        direction.y = 0; // Set the Y component to 0 to only rotate around the Y axis
        Quaternion rotation = Quaternion.LookRotation(direction);
        ScoreBoardTransform.rotation = rotation;
        // ScoreBoardTransform.LookAt(PlayerTransform, Vector3.up);

        // Check if game is over
        if(TotalScore < 0f && !GameOverAlreadyPlayed) 
        {
            GameOverAlreadyPlayed = true;
            GameOver();
        }

        // Update score to mesh
        if(GameMngr.CurrentLevelIndex == 1) 
        {
            Points.text = TotalScore.ToString("F0"); // Update points text mesh s1
        }
        if(GameMngr.CurrentLevelIndex == 2) 
        {
            Points2.text = TotalScore.ToString("F0"); // Update points text mesh s1
        }
        if(GameMngr.CurrentLevelIndex == 3) 
        {
            Points3.text = TotalScore.ToString("F0"); // Update points text mesh s1
        }
        if(GameMngr.CurrentLevelIndex == 4) 
        {
            Points4.text = TotalScore.ToString("F0"); // Update points text mesh s1
        }
        if(GameMngr.CurrentLevelIndex == 5) 
        {
            Points5.text = TotalScore.ToString("F0"); // Update points text mesh s1
        }
        

    }
    public void CheckScore()
    {
        if(TotalScore < 0) 
        {
            // 
        }
        else
        {
            ScoreMultiplier();
        }
        ScoreMenuObj.SetActive(true);

        // Revised Scoring system as of May 13, 2024
        // Check first if the current level is not 5
        if(GameMngr.CurrentLevelIndex <= 4 && GameMngr.CurrentLevelIndex > 0)
        {   
            if(TotalScore <= 25.9f) // 
            {
                Score.text = TotalScore.ToString("F0"); // Set the totalscore to score text mesh
                Performance.text = "FAILED!";
                NextBtnText.text = "TRY AGAIN!";
                NextBtnObj.SetActive(true);
                NextBtn.image.color = RedBtn;
                Stars[0].SetActive(true);
                Stars[1].SetActive(false);
                Stars[2].SetActive(false);
                Stars[3].SetActive(false);
                _AudioMngr.PlayPerformance(_AudioMngr.verdict[0]); // O star
            }
            else if(TotalScore >= 26f && TotalScore < 75.9) // 
            {
                Score.text = TotalScore.ToString("F0"); // Set the totalscore to score text mesh
                Performance.text = "GOOD!";
                NextBtnText.text = "PROCEED!";
                NextBtnObj.SetActive(true);
                NextBtn.image.color = GreenBtn;
                Stars[0].SetActive(false);
                Stars[1].SetActive(true);
                Stars[2].SetActive(false);
                Stars[3].SetActive(false);
                _AudioMngr.PlayPerformance(_AudioMngr.verdict[1]); // 1 star
            }
            else if(TotalScore >= 76f && TotalScore < 150.9f) // 
            {
                Score.text = TotalScore.ToString("F0"); // Set the totalscore to score text mesh
                Performance.text = "GREAT!";
                NextBtnText.text = "PROCEED!";
                NextBtnObj.SetActive(true);
                NextBtn.image.color = GreenBtn;
                Stars[0].SetActive(false);
                Stars[1].SetActive(false);
                Stars[2].SetActive(true);
                Stars[3].SetActive(false);
                _AudioMngr.PlayPerformance(_AudioMngr.verdict[2]); // 2 star
            }
            else if(TotalScore >= 151) // 
            {
                Score.text = TotalScore.ToString("F0"); // Set the totalscore to score text mesh
                Performance.text = "EXCELLENT!";
                NextBtnText.text = "PROCEED!";
                NextBtnObj.SetActive(true);
                NextBtn.image.color = GreenBtn;
                Stars[0].SetActive(false);
                Stars[1].SetActive(false);
                Stars[2].SetActive(false);
                Stars[3].SetActive(true);
                _AudioMngr.PlayPerformance(_AudioMngr.verdict[3]); // 3 star
            }
        }
        // If current level is 5 change button will be different
        if(GameMngr.CurrentLevelIndex == 5)
        {
            if(TotalScore <= 25.9f) // 
            {
                Score.text = TotalScore.ToString("F0"); // Set the totalscore to score text mesh
                Performance.text = "FAILED!";
                NextBtnText.text = "TRY AGAIN!";
                NextBtnObj.SetActive(true);
                NextBtn.image.color = RedBtn;
                Stars[0].SetActive(true);
                Stars[1].SetActive(false);
                Stars[2].SetActive(false);
                Stars[3].SetActive(false);
                _AudioMngr.PlayPerformance(_AudioMngr.verdict[0]); // O star
            }
            else if(TotalScore >= 26f && TotalScore < 75.9) // 
            {
                Score.text = TotalScore.ToString("F0"); // Set the totalscore to score text mesh
                Performance.text = "GOOD!";
                NextBtnText.text = "MAIN MENU!";
                NextBtnObj.SetActive(true);
                NextBtn.image.color = GreenBtn;
                Stars[0].SetActive(false);
                Stars[1].SetActive(true);
                Stars[2].SetActive(false);
                Stars[3].SetActive(false);
                _AudioMngr.PlayPerformance(_AudioMngr.verdict[1]); // 1 star
            }
            else if(TotalScore >= 76f && TotalScore < 150.9f) // 
            {
                Score.text = TotalScore.ToString("F0"); // Set the totalscore to score text mesh
                Performance.text = "GREAT!";
                NextBtnText.text = "MAIN MENU!";
                NextBtnObj.SetActive(true);
                NextBtn.image.color = GreenBtn;
                Stars[0].SetActive(false);
                Stars[1].SetActive(false);
                Stars[2].SetActive(true);
                Stars[3].SetActive(false);
                _AudioMngr.PlayPerformance(_AudioMngr.verdict[2]); // 2 star
            }
            else if(TotalScore >= 151) // 
            {
                Score.text = TotalScore.ToString("F0"); // Set the totalscore to score text mesh
                Performance.text = "EXCELLENT!";
                NextBtnText.text = "MAIN MENU!";
                NextBtnObj.SetActive(true);
                NextBtn.image.color = GreenBtn;
                Stars[0].SetActive(false);
                Stars[1].SetActive(false);
                Stars[2].SetActive(false);
                Stars[3].SetActive(true);
                _AudioMngr.PlayPerformance(_AudioMngr.verdict[3]); // 3 star
            }
        }
    }

    public void GameOver()
    {
        _HandsMnger.DisableEnableHandsInteraction(false);
        ScoreMenuObj.SetActive(true);
        Score.text = TotalScore.ToString("F0"); // Set the totalscore to score text mesh
        Performance.text = "GAME OVER!";
        NextBtnText.text = "TRY AGAIN!";
        NextBtnObj.SetActive(true);
        NextBtn.image.color = RedBtn;
        Stars[0].SetActive(true);
        Stars[1].SetActive(false);
        Stars[2].SetActive(false);
        Stars[3].SetActive(false);
        _AudioMngr.GameOverFx(); // Game Over
    }

    // Multiply total score by time finished the experiment
    public void ScoreMultiplier()
    {
        if(STcurrentTime >= 1200) // x1
        {
            TotalScore = TotalScore * 1f;
        }
        if(STcurrentTime >= 600f && STcurrentTime <= 1199f) // x1.5
        {
            TotalScore = TotalScore * 1.5f;
        }
        if(STcurrentTime >= 480f && STcurrentTime <= 599f) // x2
        {
            TotalScore = TotalScore * 2f;
        }
        if(STcurrentTime >= 360f && STcurrentTime <= 479f) // x2.5
        {
            TotalScore = TotalScore * 2.5f;
        }
        if(STcurrentTime >= 240f && STcurrentTime <= 359f) // x3
        {
            TotalScore = TotalScore * 3f;
        }
        if(STcurrentTime >= 120 && STcurrentTime <= 239f) // x3.5
        {
            TotalScore = TotalScore * 3.5f;
        }
        if(STcurrentTime >= 1f && STcurrentTime <= 119f) // x4
        {
            TotalScore = TotalScore * 4f;
        }
    }
    
    // Score Timer
    public void StartScoreTimer()
    {
        if (ScoretimerCoroutine != null)
        {
            StopCoroutine(ScoretimerCoroutine);
        }
        ScoretimerCoroutine = StartCoroutine(UpdateScoreTimer());
    }

    public void StoptScoreTimer()
    {
        if (ScoretimerCoroutine != null)
        {
            StopCoroutine(ScoretimerCoroutine);
            ScoretimerCoroutine = null;
        }
    }

    private IEnumerator UpdateScoreTimer()
    {
        float updateInterval = 1f;
        while (true)
        {
            STcurrentTime += updateInterval;
            int minutes = Mathf.FloorToInt(STcurrentTime / 60f);
            int seconds = Mathf.FloorToInt(STcurrentTime % 60f);
            Debug.Log("Score Timer: " + STcurrentTime);
            if(GameMngr.CurrentLevelIndex == 1) 
            {
                ScoreTimerMesh.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            }
            if(GameMngr.CurrentLevelIndex == 2) 
            {
                ScoreTimerMesh2.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            }
            if(GameMngr.CurrentLevelIndex == 3) 
            {
                ScoreTimerMesh3.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            }
            if(GameMngr.CurrentLevelIndex == 4) 
            {
                ScoreTimerMesh4.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            }
            if(GameMngr.CurrentLevelIndex == 5) 
            {
                ScoreTimerMesh5.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            }
            yield return new WaitForSeconds(updateInterval);
        }
    }

    public void Deductions(string deductions)
    {
        if(deductions == "ForgotValve")
        {
            TotalScore = TotalScore - 15f;
            _AudioMngr.PlayDeduction(_AudioMngr.DeductionClips[0]); 
        }
        if(deductions == "SpilledChem")
        {
            TotalScore = TotalScore - 5f;
            _AudioMngr.PlayDeduction(_AudioMngr.DeductionClips[1]); 
        }
        if(deductions == "DropBeakerTube")
        {
            TotalScore = TotalScore - 50f;
            _AudioMngr.PlayDeduction(_AudioMngr.DeductionClips[2]); 
        }
        if(deductions == "WrongBeakerTube")
        {
            TotalScore = TotalScore - 30f;
            _AudioMngr.PlayDeduction(_AudioMngr.DeductionClips[3]); 
        }
        if(deductions == "ChemNotYetDone")
        {
            TotalScore = TotalScore - 10f;
            _AudioMngr.PlayDeduction(_AudioMngr.DeductionClips[4]); 
        }
        if(deductions == "SkipProcess")
        {
            TotalScore = TotalScore - 20f;
            _AudioMngr.PlayDeduction(_AudioMngr.DeductionClips[5]); 
        }
        if(deductions == "PlaysLighter")
        {
            TotalScore = TotalScore - 20f;
            _AudioMngr.PlayDeduction(_AudioMngr.DeductionClips[6]); 
        }
    }
}
