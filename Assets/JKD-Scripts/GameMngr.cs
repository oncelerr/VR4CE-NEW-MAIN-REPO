using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameMngr : MonoBehaviour
{
    [Header("Checkmarks")]
    public GameObject[] s1StepChecks;
    public GameObject[] s2StepChecks;
    public GameObject[] s3StepChecks; 
    public GameObject[] s4StepChecks;
    public GameObject[] s5StepChecks;


    [Header("Scripts")]
    [SerializeField] Checkpoint _Checkpoint;
    [SerializeField] SceneLoader _SceneLoader;
    [SerializeField] DataMngr _DataMngr;
    [SerializeField] ScoreMngr _ScoreMngr;
    [SerializeField] AudioMngr _AudioMngr;
    [SerializeField] doorAnimation _doorAnimation;
    [SerializeField] vrRobot _vrRobot;

    [Header("Lab Materials")]
    [SerializeField] GameObject[] _LabMaterials;
    
    [Header("Others")]
    public BoxCollider _doorTrigger;
    public BoxCollider _doorTrigger2;
    

    // Database to static variable realtime reference
    public static int CurrentLevelIndex;

    // Level Control
    public static bool level1Done = false;
    public static bool level2Done = false;
    public static bool level3Done = false;
    public static bool level4Done = false;
    public static bool level5Done = false;
 

    // Level Activation
    private bool ppeRoomDone = false;
    private bool lvl1Activated = false;
    private bool lvl2Activated = false;
    private bool lvl3Activated = false;
    private bool lvl4Activated = false;
    private bool lvl5Activated = false;

    // Checkpoints
    public static bool Cpoint1 = false;
    public static bool Cpoint2 = false;
    public static bool Cpoint3 = false;
    public static bool Cpoint4 = false;
    public static bool Cpoint5 = false;
    public static bool Cpoint6 = false;
    public static bool Cpoint7 = false;
 
    // Misc Variables
    public static bool ppe_ready = false;
    public static float S1currentsteps = 0;
    public static float S2currentsteps = 0;
    public static float S3currentsteps = 0;
    public static float S4currentsteps = 0;
    public static float S5currentsteps = 0;
    public static bool alreadyReachLastStep;
    private bool lab1ReachTable;
    private bool lab2Reach;
    private bool lab2ReachTable;
    private bool lab2Reach2Table2;
    private bool lab2ReachTable2;
    private bool mainlab2ReachTable2;
    private bool mainlabReachTable;
    private bool step7active = false;


    public static int s1nextstep = 0;
    public static int s2nextstep = 0;
    public static int s3nextstep = 0;
    public static int s4nextstep = 0;
    public static int s5nextstep = 0;

    public static int s1Currtstep = 1;
    private int s2Currtstep = 1;
    public static int s3Currtstep = 1;
    public static int s4Currtstep = 1;
    public static int s5Currtstep = 1;


    public static bool S2SpilledChemPowder;
    public static int S3valveStep = 1;
    public static int S1hoseStep = 1;
    public static int whichMetal = 1;
    public static int s5tubestep = 1;
    private bool s5standby = true;


    private void Awake() 
    {
        if(_doorAnimation == null)
        {
            Debug.LogError("_doorAnimation script is not reference!");
        }
        else if(_vrRobot == null)
        {
            Debug.LogError("_vrRobot script is not reference!");
        }
        else if(_doorTrigger == null)
        {
            Debug.LogError("_doorTrigger script is not reference!");
        }
    }
    
    private void Start() 
    {   
        // Reset Variables
        s5standby = true;
        whichMetal = 1;
        S1hoseStep = 1;
        S3valveStep = 1;
        step7active = false;
        ppe_ready = false;
        alreadyReachLastStep = false;
        lab1ReachTable = false;
        lab2Reach = false;
        ppeRoomDone = false;
        lab2ReachTable = false;
        lab2Reach2Table2 = false;
        lab2ReachTable2 = false;
        mainlab2ReachTable2 = false;
        S2SpilledChemPowder = false;
        mainlabReachTable = false;
        S1currentsteps = 0;
        S2currentsteps = 0;
        S3currentsteps = 0;
        S4currentsteps = 0;
        S5currentsteps = 0;

        s1Currtstep = 1;
        s2Currtstep = 1;
        s3Currtstep = 1;
        s4Currtstep = 1;
        s5Currtstep = 1;

        // Reference the updated level from the database to static variable
        _DataMngr.LoadMyData();
        CurrentLevelIndex = _DataMngr.player.LevelIndex;

        Debug.Log("The current level is: " +CurrentLevelIndex);
        // Load the level base on the current level from database
        // Setup what level it is
        if(_DataMngr.player.LevelIndex == 1) 
        {
            Debug.Log("LEVEL 1");
            EnableDisableGameObjects(_DataMngr.player.LevelIndex, _LabMaterials);
            _vrRobot.p1();
            Debug.Log("Level 1 is executed");
        }
        else if(_DataMngr.player.LevelIndex == 2) 
        {
            Debug.Log("LEVEL 2");
            EnableDisableGameObjects(_DataMngr.player.LevelIndex, _LabMaterials);
            _vrRobot.p4();
        }
        else if(_DataMngr.player.LevelIndex == 3) 
        {
            Debug.Log("LEVEL 3");
            EnableDisableGameObjects(_DataMngr.player.LevelIndex, _LabMaterials);
            _vrRobot.p7();
        }
        else if(_DataMngr.player.LevelIndex == 4) 
        {
            Debug.Log("LEVEL 4");
            EnableDisableGameObjects(_DataMngr.player.LevelIndex, _LabMaterials);
            _vrRobot.p10();
        }
        else if(_DataMngr.player.LevelIndex == 5) 
        {
            Debug.Log("LEVEL 5");
            EnableDisableGameObjects(_DataMngr.player.LevelIndex, _LabMaterials);
            _vrRobot.p13();
        }
    }

    private void Update() 
    {
        // Update steps checklist
        switch (CurrentLevelIndex)
        {
            case 1:
                s1StepChecks[Mathf.CeilToInt(S1currentsteps)].SetActive(true);
                break;
            case 2:
                s2StepChecks[Mathf.CeilToInt(S2currentsteps)].SetActive(true);
                break;
            case 3:
                s3StepChecks[Mathf.CeilToInt(S3currentsteps)].SetActive(true);
                break;
            case 4:
                s4StepChecks[Mathf.CeilToInt(S4currentsteps)].SetActive(true);
                break;
            case 5:
                s5StepChecks[Mathf.CeilToInt(S5currentsteps)].SetActive(true);
                break;
            default:
                break;
        }
        
        
        

        //PPE check all sublevels
        if(ppe_ready && !ppeRoomDone) 
        {
            if(_DataMngr.player.LevelIndex == 1)
            {
                ppeRoomDone = true;
                _doorTrigger.enabled = true;
                _doorAnimation.OpenDoor();
                DOTween.Kill("p1"); // Pause scripts 1-7 if player is already ppe ready
                _vrRobot.p2(); 
            }
            else if(_DataMngr.player.LevelIndex == 2)
            {
                ppeRoomDone = true;
                _doorTrigger.enabled = true;
                _doorAnimation.OpenDoor();
                DOTween.Kill("p4"); // Pause scripts 1-7 if player is already ppe ready
                _vrRobot.p5();
            }
            else if(_DataMngr.player.LevelIndex == 3)
            {
                ppeRoomDone = true;
                _doorTrigger.enabled = true;
                _doorAnimation.OpenDoor();
                DOTween.Kill("p7"); // Pause scripts 1-7 if player is already ppe ready
                _vrRobot.p8();
            }
            else if(_DataMngr.player.LevelIndex == 4)
            {
                ppeRoomDone = true;
                _doorTrigger.enabled = true;
                _doorAnimation.OpenDoor();
                DOTween.Kill("p10"); // Pause scripts 1-7 if player is already ppe ready
                _vrRobot.p11();
            }
            else if(_DataMngr.player.LevelIndex == 5)
            {
                ppeRoomDone = true;
                _doorTrigger.enabled = true;
                _doorAnimation.OpenDoor();
                DOTween.Kill("p13"); // Pause scripts 1-7 if player is already ppe ready
                _vrRobot.p14();
            }
        }

        // CHECKPOINTS
        // Check if the player reach the table sub1
        if(CurrentLevelIndex == 1 && Checkpoint._CheckpointIndexSub1 == 2 && !lab1ReachTable)  // SUB 1
        {
            lab1ReachTable = true;
            _vrRobot.p3();
        }

        // Check if the player reach the lab 2 sub2
        if(CurrentLevelIndex == 2 && Checkpoint._CheckpointIndexSub2 == 3 && !lab2Reach)  //SUB2
        {
            lab2Reach = true;
            _Checkpoint.ShowCheckpoint(Checkpoint._CheckpointIndexSub2);
        }

        // Check if the player reach the lab 2 sub2 and already near the table
        if(CurrentLevelIndex == 2 && Checkpoint._CheckpointIndexSub2 == 4 && !lab2ReachTable)  //SUB2
        {
            lab2ReachTable = true;
            _vrRobot.p6();
        }

        // Check if the player reach the main lab sub3 and already near the table
        if(CurrentLevelIndex == 3 && Checkpoint._CheckpointIndexSub3 == 5 && !mainlabReachTable)  //SUB3
        {
            mainlabReachTable = true;
            _vrRobot.p9();
        }

        // Check if the player reach the main lab sub4 and already near the table
        if(CurrentLevelIndex == 4 && Checkpoint._CheckpointIndexSub4 == 6 && !lab2Reach2Table2)  //SUB4
        {
            lab2Reach2Table2 = true;
            _Checkpoint.ShowCheckpoint(Checkpoint._CheckpointIndexSub4);
        }

        // Check if the player reach the main lab sub4 and already near the table
        if(CurrentLevelIndex == 4 && Checkpoint._CheckpointIndexSub4 == 7 && !lab2ReachTable2)  //SUB4
        {
            lab2ReachTable2 = true;
            _vrRobot.p12();
        }

        // Check if the player reach the main lab sub4 and already near the table
        if(CurrentLevelIndex == 5 && Checkpoint._CheckpointIndexSub5 == 8 && !mainlab2ReachTable2)  //SUB5
        {
            mainlab2ReachTable2 = true;
            _vrRobot.p15();
        }
    }

    public void ProceedToNextLevel()
    {
        if(ScoreMngr.TotalScore <= 25.9f) 
        {
            ResetLvl(CurrentLevelIndex);
        }
        else
        {
            if(CurrentLevelIndex == 1) // if current level is 1, load level 2
            {
                _ScoreMngr.ScoreMenuObj.SetActive(false);
                _DataMngr.player.LevelIndex = 2; // this change every succeeding level
                _DataMngr.SaveMyData(); // saving the progress
                _SceneLoader.LoadScene(3);  //NOTE: this is constant, because we are using the same scene. THis will change if the player reach level 5 because he/she will be redirect to main menu.
            }
            if(CurrentLevelIndex == 2) // if current level is 2, load level 3
            {
                _ScoreMngr.ScoreMenuObj.SetActive(false);
                _DataMngr.player.LevelIndex = 3;  // this change every succeeding level
                _DataMngr.SaveMyData(); // saving the progress
                _SceneLoader.LoadScene(3); //NOTE: this is constant
            }
            if(CurrentLevelIndex == 3) // if current level is 3, load level 4
            {
                _ScoreMngr.ScoreMenuObj.SetActive(false);
                _DataMngr.player.LevelIndex = 4;  // this change every succeeding level
                _DataMngr.SaveMyData(); // saving the progress
                _SceneLoader.LoadScene(3); //NOTE: this is constant
            }
            if(CurrentLevelIndex == 4) // if current level is 4, load level 5
            {
                _ScoreMngr.ScoreMenuObj.SetActive(false);
                _DataMngr.player.LevelIndex = 5;  // this change every succeeding level
                _DataMngr.SaveMyData(); // saving the progress
                _SceneLoader.LoadScene(3); //NOTE: this is constant
            }
            if(CurrentLevelIndex == 5) // if current level is 5, load Main menu
            {
                _ScoreMngr.ScoreMenuObj.SetActive(false);
                _DataMngr.player.LevelIndex = 5;  // Change this if you have save load system, if you want the player to select which level he/she will play
                _DataMngr.SaveMyData(); // saving the progress
                _SceneLoader.LoadScene(0); // this will load the main menu 
            }
        }
    }
    
    public void ResetLvl(int level)
    {
        switch (level)
        {
            case 1:
                _DataMngr.player.LevelIndex = 1;
                _DataMngr.SaveMyData();
                _SceneLoader.RestartScene();
                break;
            case 2:
                _DataMngr.player.LevelIndex = 2;
                _DataMngr.SaveMyData();
                _SceneLoader.RestartScene();
                break;
            case 3:
                _DataMngr.player.LevelIndex = 3;
                _DataMngr.SaveMyData();
                _SceneLoader.RestartScene();
                break;
            case 4:
                _DataMngr.player.LevelIndex = 4;
                _DataMngr.SaveMyData();
                _SceneLoader.RestartScene();
                break;
            case 5:
                _DataMngr.player.LevelIndex = 5;
                _DataMngr.SaveMyData();
                _SceneLoader.RestartScene();
                break;
            default:
                break;
        }
    }

    public void EnableDisableGameObjects(int ToEnableObj, GameObject[] Array)
    {
        Array[ToEnableObj].SetActive(true);
        // disable other lab materials
        for(int i = 0; i < Array.Length; i++) {
            if (i != ToEnableObj) // Skip the object that will be enable
            {
                Array[i].SetActive(false);
            }
        }
    }

    public void SelectNextstep(int step)
    {
        if(CurrentLevelIndex == 1) 
        {
            Debug.Log("Input "+step);
            Debug.Log("Compare to "+s1Currtstep);

            if(step == s1Currtstep && S1hoseStep == 1) //1,2
            {
                s1Currtstep++;
            }
            else if(step == S1hoseStep) //1 safe snapper
            {
                // 
            }
            else if(step == s1Currtstep)//2, 4
            {
                // 
            }
            else if(step == 2 && s1Currtstep == 5)//2, 4
            {
                s1Currtstep++;
            }
            else // deduction
            {
                _ScoreMngr.Deductions("SkipProcess");
            }
        }
        if(CurrentLevelIndex == 2) 
        {
            Debug.Log("Input "+step);
            Debug.Log("Compare to "+s2Currtstep);
            if(step == s2Currtstep)//1,2,3,4
            {
                s2Currtstep++;
            }
            else // deduction
            {
                _ScoreMngr.Deductions("SkipProcess");
            }
        }
        if(CurrentLevelIndex == 3) 
        {
            Debug.Log("Input "+step);
            Debug.Log("Compare to "+s3Currtstep);
            
            if(step == s3Currtstep && s3TestTubeContent.testtubeHoldingByHuman) // 1
            {
                s3Currtstep++;
                Debug.Log("Step 1 added 1 for next step(2)");
            }
            else if(step == 1 && S3valveStep == 1)
            {
                //default
            }
            else if(step == s3Currtstep && step != 4) //2,3,5
            {
                s3Currtstep++;
            }
            else if(step == 4 && S3valveStep == 1) //4
            {
                // 
            }
            else if(step == 4 && S3valveStep == 2) //6
            {
                // 
            }
            else if(step == 4 && S3valveStep == 3) //7
            {
                // 
            }
            else // deduction
            {
                _ScoreMngr.Deductions("SkipProcess");
            }
        }
        if(CurrentLevelIndex == 4) 
        {
            Debug.Log("Input "+step);
            Debug.Log("Compare to "+s4Currtstep);
            
            if(step == s4Currtstep) // 1, copper sulfate -- 2, silver nitrate, 3, hydro, 4, lead, 5, magnes, 6, hyrdro
            {
                // s4Currtstep++;
            }

            else // deduction
            {
                _ScoreMngr.Deductions("WrongBeakerTube");
            }
        }
        if(CurrentLevelIndex == 5) 
        {
            Debug.Log("Input "+step);
            Debug.Log("Compare to "+s5Currtstep);
            
            if(step == s5Currtstep && s5TestTubeContent.S5testtubeHoldingByHuman && s5tubestep == 1) // 1, 
            {
                s5Currtstep++;
                s5tubestep++;
                Debug.Log("Step 1, Holding by player and s5Currtstep = "+s5Currtstep);
            }
            else if(step == 1 && s5Currtstep == 2 && s5tubestep == 2) // 2, 
            {
                s5Currtstep++;
                Debug.Log("Step 2, s5Currtstep = "+s5Currtstep);
            }
            else if(step == s5Currtstep && s5tubestep == 2) // 3, 4
            {
                s5Currtstep++;
                Debug.Log("Step 3, s5Currtstep = "+s5Currtstep);
            }
            else if(step == 1) // 1, 
            {
                // s5standby = false;
                Debug.Log("standby, s5Currtstep = "+s5Currtstep);
            }
           
            else // deduction   
            {
                _ScoreMngr.Deductions("SkipProcess");
            }
        }
    }

    public void SelectMetal(int metal)
    {
        if(metal == 1 && metal == s4Currtstep )//1, magnesium
        {
            // whichMetal++;
        }
        else if(metal == 3 && whichMetal == s4Currtstep )//3, copper
        {
            // whichMetal++;//3
        }
        else if(metal == 3 && whichMetal == s4Currtstep )//3, copper
        {
            // whichMetal++;//4
        }
        else if(metal == 2 && whichMetal == s4Currtstep )//2, zinc
        {
            // whichMetal++;//5
        }
        else if(metal == 2 && whichMetal == s4Currtstep )//2, zinc
        {
            // whichMetal++;//6
        }
        else if(metal == 2 && whichMetal == s4Currtstep )//2, zinc
        {
            // 
        }
        else // deduction
        {
            _ScoreMngr.Deductions("SkipProcess");
        }
    }
}
