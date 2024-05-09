using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameMngr : MonoBehaviour
{
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


    // 
    public static bool S2SpilledChemPowder;



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
        //PPE check all sublevels
        if(ppe_ready && !ppeRoomDone) 
        {
            if(_DataMngr.player.LevelIndex == 1)
            {
                ppeRoomDone = true;
                _doorTrigger.enabled = true;
                _doorAnimation.OpenDoor();
                DOTween.Pause("p1"); // Pause scripts 1-7 if player is already ppe ready
                _vrRobot.p2(); 
            }
            else if(_DataMngr.player.LevelIndex == 2)
            {
                ppeRoomDone = true;
                _doorTrigger.enabled = true;
                _doorAnimation.OpenDoor();
                DOTween.Pause("p4"); // Pause scripts 1-7 if player is already ppe ready
                _vrRobot.p5();
            }
            else if(_DataMngr.player.LevelIndex == 3)
            {
                ppeRoomDone = true;
                _doorTrigger.enabled = true;
                _doorAnimation.OpenDoor();
                DOTween.Pause("p7"); // Pause scripts 1-7 if player is already ppe ready
                _vrRobot.p8();
            }
            else if(_DataMngr.player.LevelIndex == 4)
            {
                ppeRoomDone = true;
                _doorTrigger.enabled = true;
                _doorAnimation.OpenDoor();
                DOTween.Pause("p10"); // Pause scripts 1-7 if player is already ppe ready
                _vrRobot.p11();
            }
            else if(_DataMngr.player.LevelIndex == 5)
            {
                ppeRoomDone = true;
                _doorTrigger.enabled = true;
                _doorAnimation.OpenDoor();
                DOTween.Pause("p13"); // Pause scripts 1-7 if player is already ppe ready
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


}
