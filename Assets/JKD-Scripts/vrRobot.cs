using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class vrRobot : MonoBehaviour
{
    [SerializeField] HandsMnger _HandsMnger;
    [SerializeField] ScoreMngr _ScoreMngr;
    [SerializeField] AudioMngr _AudioMngr;
    [SerializeField] GameMngr _GameMngr;
    [SerializeField] Checkpoint _Checkpoint;
    [SerializeField] GameObject[] _BoardContent;
    [SerializeField] GameObject _subtitlePanel;
    [SerializeField] public GameObject[] _subtitles;
    [SerializeField] public GameObject[] _subtitles2;
    [SerializeField] public GameObject[] _subtitles3;
    [SerializeField] public GameObject[] _subtitles4;
    [SerializeField] public GameObject[] _subtitles5;
    [SerializeField] doorAnimation _doorAnimation;
    [SerializeField] doorAnimation2 _doorAnimation2;
    public float hoverHeight = 1f;
    public Vector3[] position;
    private float hoverSpeed = 1f;
    public int currScript;
    public int prevScript;
    public static bool currentStepExecuted = false;
    public static bool currentStepExecuted2 = false;
    public static bool currentStepExecuted3 = false;
    public static bool currentStepExecuted4 = false;
    public static bool currentStepExecuted5 = false;
    Sequence hoverSequence;

    //Misc variables
    private bool alreadyPlayedSpilledFunction;

    // In this method, it checks here if the scripts are referenced in the editor.
    private void Awake() 
    {
        if(_Checkpoint == null)
        {
            Debug.LogError("_Checkpoint script is not reference!");
        }
    }
    
    private void Start() 
    {
        // Reset Variables
        currentStepExecuted = false;
        currScript = 0;
        prevScript = 0;
        alreadyPlayedSpilledFunction = false;
    }
    
    private void Update() 
    {
        // Steps for level 1 
        Sub1ExperimentSteps();
        // Steps for level 2
        Sub2ExperimentSteps();
        // Steps for level 3
        Sub3ExperimentSteps();
        // Steps for level 4
        Sub4ExperimentSteps();
        // Steps for level 5
        Sub5ExperimentSteps();
        
    }
    
    
    // SUBLEVEL 1


    public void p1() //PPE Check sub1
    {
        Sequence p1sequence = DOTween.Sequence().SetId("p1");
        p1sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Panel off
        p1sequence.AppendInterval(1.7f);  // Delay
        p1sequence.AppendCallback(() => _doorAnimation.OpenDoor()); // s20
        p1sequence.AppendInterval(1f);  // Delay
        p1sequence.Append(transform.DOMove(position[1], 2f));  // VRBot will enter the PPE room
        p1sequence.AppendCallback(() => _doorAnimation.CloseDoor()); // PPE room door will close
        p1sequence.AppendCallback(() => RotateVRbot(360f, 1f)); // VRBot will face the player
        p1sequence.AppendCallback(() => HoverVRbot(true)); // VRBot will hover
        p1sequence.AppendInterval(1.5f); // Delay of 1.5s
        p1sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active
        p1sequence.AppendCallback(() => PlayVRbotScript(1)); // s1       Subtitle 2 text will be set active
        p1sequence.AppendInterval(_AudioMngr.vrBotVoice[1].length); // Add delay according to the voice over`s duration
        p1sequence.AppendCallback(() => PlayVRbotScript(2)); // s2     
        p1sequence.AppendInterval(_AudioMngr.vrBotVoice[2].length); // Delay
        p1sequence.AppendCallback(() => PlayVRbotScript(3)); // s3      
        p1sequence.AppendInterval(_AudioMngr.vrBotVoice[3].length); // Delay
        p1sequence.AppendCallback(() => PlayVRbotScript(4)); // s4      
        p1sequence.AppendInterval(_AudioMngr.vrBotVoice[4].length+.5f); // Delay + 3s for a bit pause
        p1sequence.AppendCallback(() => PlayVRbotScript(5)); // s5      
        p1sequence.AppendInterval(_AudioMngr.vrBotVoice[5].length); // Delay
        p1sequence.AppendCallback(() => PlayVRbotScript(6)); // s6      
        p1sequence.AppendInterval(_AudioMngr.vrBotVoice[6].length); // Delay
        p1sequence.AppendCallback(() => PlayVRbotScript(7)); // s7      
        p1sequence.Play(); 
    }

    public void p2()
    {
        Sequence p2sequence = DOTween.Sequence();
        p2sequence.AppendCallback(() => PlayVRbotScript(8)); // s8
        p2sequence.AppendInterval(_AudioMngr.vrBotVoice[8].length); // Delay
        p2sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Subtitle panel will be set inactive
        p2sequence.AppendCallback(() => RotateVRbot(90f, .2f)); // VRBot will face the exit room
        p2sequence.AppendInterval(.3f); // Delay of .3s
        p2sequence.Append(transform.DOMove(position[2], 1.5f)); // VRBot will exit the PPE room
        p2sequence.AppendCallback(() => HoverVRbot(false));  //VRBot`s hover is set inactive
        p2sequence.AppendCallback(() => RotateVRbot(450f, .3f)); 
        p2sequence.AppendCallback(() => RotateVRbot(-90f, .3f));
        p2sequence.AppendCallback(() => HoverVRbot(true));
        p2sequence.Play(); 

        // This sequence triggers if the player entered to the main lab
        Sequence p21sequence = DOTween.Sequence().SetId("p21");
        p21sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active
        p21sequence.AppendCallback(() => PlayVRbotScript(9)); // s9
        p21sequence.AppendInterval(_AudioMngr.vrBotVoice[9].length); // Delay
        p21sequence.AppendCallback(() => _Checkpoint.ShowCheckpoint(Checkpoint._CheckpointIndexSub1));
        p21sequence.Pause(); 

    }

    public void p3()  
    {
        Sequence p3sequence = DOTween.Sequence();
        p3sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Subtitle panel will be set inactive
        p3sequence.AppendCallback(() => HoverVRbot(false)); //Hover OFF 
        p3sequence.AppendCallback(() => RotateVRbot(34.1f, .3f));   //VRBot will face to the 3rd position
        p3sequence.AppendInterval(.5f);  // Delay of .5s
        p3sequence.Append(transform.DOMove(position[3], 1.5f));  //VRBot will move to the 3rd position
        p3sequence.AppendCallback(() => RotateVRbot(120f, .3f));   //VRBot will face the player
        p3sequence.AppendInterval(.5f);  // Delay of .5s
        p3sequence.AppendCallback(() => HoverVRbot(true));  // Hover ON
        p3sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active
        p3sequence.AppendCallback(() => PlayVRbotScript(10)); // s10
        p3sequence.AppendInterval(_AudioMngr.vrBotVoice[10].length); // Delay
        p3sequence.AppendCallback(() => PlayVRbotScript(11)); // s11
        p3sequence.AppendInterval(_AudioMngr.vrBotVoice[11].length); // Delay
        p3sequence.AppendCallback(() => _BoardContent[1].SetActive(true)); // activate board content
        p3sequence.AppendCallback(() => PlayVRbotScript(12)); // s12
        p3sequence.AppendInterval(_AudioMngr.vrBotVoice[12].length); // Delay
        p3sequence.AppendCallback(() => PlayVRbotScript(13)); // s13
        p3sequence.AppendInterval(_AudioMngr.vrBotVoice[13].length); // Delay
        p3sequence.AppendCallback(() => _HandsMnger.DisableEnableHandsInteraction(true)); // Enable hands interaction 
        p3sequence.Play(); 
    }

    
    
    // SUBLEVEL 2


    public void p4() //PPE Check sub2
    {
        Sequence p4sequence = DOTween.Sequence().SetId("p4");
        p4sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Panel off
        p4sequence.AppendCallback(() => HoverVRbot(false));// Hover OFF   
        p4sequence.AppendInterval(1.7f);  // Delay
        p4sequence.AppendCallback(() => _doorAnimation.OpenDoor()); // Open PPE room door 
        p4sequence.AppendInterval(.3f);  // Delay 
        p4sequence.Append(transform.DOMove(position[1], 2f));  // VRBot will enter the PPE room
        p4sequence.AppendCallback(() => _doorAnimation.CloseDoor()); // PPE room door will close
        p4sequence.AppendCallback(() => RotateVRbot(360f, 1f)); // VRBot will face the player
        p4sequence.AppendCallback(() => HoverVRbot(true)); // Hover ON
        p4sequence.AppendInterval(1.5f); // Delay of 1.5s
        p4sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active
        p4sequence.AppendCallback(() => PlayVRbotScript2(1)); // s1       Subtitle 2 text will be set active
        p4sequence.AppendInterval(_AudioMngr.vrBotVoice2[1].length); // Add delay according to the voice over`s duration
        p4sequence.AppendCallback(() => PlayVRbotScript2(2)); // s2     
        p4sequence.AppendInterval(_AudioMngr.vrBotVoice2[2].length); // Delay
        p4sequence.AppendCallback(() => PlayVRbotScript2(3)); // s3      
        p4sequence.AppendInterval(_AudioMngr.vrBotVoice2[3].length); // Delay
        p4sequence.AppendCallback(() => PlayVRbotScript2(4)); // s4      
        p4sequence.AppendInterval(_AudioMngr.vrBotVoice2[4].length+.5f); // Delay + 3s for a bit pause
        p4sequence.AppendCallback(() => PlayVRbotScript2(5)); // s5      
        p4sequence.AppendInterval(_AudioMngr.vrBotVoice2[5].length); // Delay
        p4sequence.AppendCallback(() => PlayVRbotScript2(6)); // s6      
        p4sequence.AppendInterval(_AudioMngr.vrBotVoice2[6].length); // Delay
        p4sequence.AppendCallback(() => PlayVRbotScript2(7)); // s7      
        p4sequence.Play(); 

    }

    public void p5()
    {
        Sequence p5sequence = DOTween.Sequence();
        p5sequence.AppendCallback(() => PlayVRbotScript2(8)); // s8
        p5sequence.AppendInterval(_AudioMngr.vrBotVoice2[8].length); // Delay
        p5sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Subtitle panel will be set inactive
        p5sequence.AppendCallback(() => RotateVRbot(90f, .2f)); // VRBot will face the exit room
        p5sequence.AppendInterval(.3f); // Delay of .3s
        p5sequence.Append(transform.DOMove(position[2], 1.5f)); // VRBot will exit the PPE room
        p5sequence.AppendCallback(() => HoverVRbot(false));  //VRBot`s hover is set inactive
        p5sequence.AppendCallback(() => RotateVRbot(450f, .3f)); 
        p5sequence.AppendCallback(() => RotateVRbot(-90f, .3f));
        p5sequence.AppendCallback(() => HoverVRbot(true)); //Hover ON
        p5sequence.Play(); 

        // This sequence triggers if the player entered to the main lab
        Sequence p51sequence = DOTween.Sequence().SetId("p51");
        p51sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active
        p51sequence.AppendCallback(() => PlayVRbotScript2(9)); // s9
        p51sequence.AppendInterval(_AudioMngr.vrBotVoice2[9].length); // Delay
        p51sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Subtitle panel will be set inactive
        p51sequence.AppendCallback(() => _Checkpoint.ShowCheckpoint(Checkpoint._CheckpointIndexSub2));  // Show next path 
        p51sequence.AppendCallback(() => HoverVRbot(false)); //Hover OFF
        p51sequence.AppendCallback(() => RotateVRbot(0f, .2f)); // VRBot will face the laboratory 2 
        p51sequence.Append(transform.DOMove(position[5], 2f)); // VRBot will go to laboratory 2
        p51sequence.AppendCallback(() => _doorAnimation2.OpenDoor2()); // Laboratory 2 door will open
        p51sequence.Append(transform.DOMove(position[6], 1f)); // VRBot will go to laboratory 2
        p51sequence.Append(transform.DOMove(position[7], 1f)); // VRBot will go above the table
        p51sequence.AppendCallback(() => RotateVRbot(-90f, .2f)); // VRBot will face the player
        p51sequence.AppendCallback(() => HoverVRbot(true)); //Hover ON
        p51sequence.AppendCallback(() => _GameMngr._doorTrigger2.enabled = true); // Lab 2 door will be enabled
        p51sequence.AppendCallback(() => _Checkpoint.ShowCheckpoint(Checkpoint._CheckpointIndexSub2));  // Show next path 
        p51sequence.Pause(); 
    }

    public void p6()
    {
        Sequence p6sequence = DOTween.Sequence();
        p6sequence.AppendInterval(1f); // Delay
        p6sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active
        p6sequence.AppendCallback(() => PlayVRbotScript2(10)); // s10
        p6sequence.AppendInterval(_AudioMngr.vrBotVoice2[10].length); // Delay
        p6sequence.AppendCallback(() => PlayVRbotScript2(11)); // s11
        p6sequence.AppendInterval(_AudioMngr.vrBotVoice2[11].length); // Delay
        p6sequence.AppendCallback(() => _BoardContent[2].SetActive(true)); // activate board content
        p6sequence.AppendCallback(() => PlayVRbotScript2(12)); // s12s
        p6sequence.AppendInterval(_AudioMngr.vrBotVoice2[12].length); // Delay
        p6sequence.AppendCallback(() => PlayVRbotScript2(13)); // s13s
        p6sequence.AppendInterval(_AudioMngr.vrBotVoice2[13].length); // Delay
        p6sequence.AppendCallback(() => _HandsMnger.DisableEnableHandsInteraction(true)); // Enable hands interaction 
        p6sequence.Play(); 
    }
    

    // SUBLEVEL 3


    public void p7() //PPE Check sub3
    {
        Sequence p7sequence = DOTween.Sequence().SetId("p7");
        p7sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Panel off
        p7sequence.AppendCallback(() => HoverVRbot(false));// Hover OFF   
        p7sequence.AppendInterval(1.7f);  // Delay
        p7sequence.AppendCallback(() => _doorAnimation.OpenDoor()); // Open PPE room door 
        p7sequence.AppendInterval(.3f);  // Delay 
        p7sequence.Append(transform.DOMove(position[1], 2f));  // VRBot will enter the PPE room
        p7sequence.AppendCallback(() => _doorAnimation.CloseDoor()); // PPE room door will close
        p7sequence.AppendCallback(() => RotateVRbot(360f, 1f)); // VRBot will face the player
        p7sequence.AppendCallback(() => HoverVRbot(true)); // Hover ON
        p7sequence.AppendInterval(1.5f); // Delay of 1.5s
        p7sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active

            // Subtitles starts here

        p7sequence.AppendCallback(() => PlayVRbotScript3(1)); // s1       Subtitle 2 text will be set active
        p7sequence.AppendInterval(_AudioMngr.vrBotVoice3[1].length); // Add delay according to the voice over`s duration
        p7sequence.AppendCallback(() => PlayVRbotScript3(2)); // s2     
        p7sequence.AppendInterval(_AudioMngr.vrBotVoice3[2].length); // Delay
        p7sequence.AppendCallback(() => PlayVRbotScript3(3)); // s3      
        p7sequence.AppendInterval(_AudioMngr.vrBotVoice3[3].length); // Delay
        p7sequence.AppendCallback(() => PlayVRbotScript3(4)); // s4      
        p7sequence.AppendInterval(_AudioMngr.vrBotVoice3[4].length+.5f); // Delay + 3s for a bit pause
        p7sequence.AppendCallback(() => PlayVRbotScript3(5)); // s5      
        p7sequence.AppendInterval(_AudioMngr.vrBotVoice3[5].length); // Delay
        p7sequence.AppendCallback(() => PlayVRbotScript3(6)); // s6      
        p7sequence.AppendInterval(_AudioMngr.vrBotVoice3[6].length); // Delay
        p7sequence.AppendCallback(() => PlayVRbotScript3(7)); // s7      
        p7sequence.Play(); 

    }
    
    public void p8()
    {
        Sequence p8sequence = DOTween.Sequence();
        p8sequence.AppendCallback(() => PlayVRbotScript3(8)); // s8
        p8sequence.AppendInterval(_AudioMngr.vrBotVoice3[8].length); // Delay
        p8sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Subtitle panel will be set inactive
        p8sequence.AppendCallback(() => RotateVRbot(90f, .2f)); // VRBot will face the exit room
        p8sequence.AppendInterval(.3f); // Delay of .3s
        p8sequence.Append(transform.DOMove(position[2], 1.5f)); // VRBot will exit the PPE room
        p8sequence.AppendCallback(() => HoverVRbot(false));  //VRBot`s hover is set inactive
        p8sequence.AppendCallback(() => RotateVRbot(450f, .3f)); 
        p8sequence.AppendCallback(() => RotateVRbot(-90f, .3f));
        p8sequence.AppendCallback(() => HoverVRbot(true)); //Hover ON
        p8sequence.Play(); 

        
        // This sequence triggers if the player entered to the main lab
        Sequence p81sequence = DOTween.Sequence().SetId("p81");
        p81sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active
        p81sequence.AppendCallback(() => PlayVRbotScript3(9)); // s9
        p81sequence.AppendInterval(_AudioMngr.vrBotVoice3[9].length); // Delay
        p81sequence.AppendCallback(() => _Checkpoint.ShowCheckpoint(Checkpoint._CheckpointIndexSub3));  // Show next path
        p81sequence.Pause(); 
    }

    public void p9()
    {
        Sequence p9sequence = DOTween.Sequence();
        p9sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Subtitle panel will be set inactive
        p9sequence.AppendCallback(() => HoverVRbot(false)); //Hover OFF 
        p9sequence.AppendCallback(() => RotateVRbot(90f, .3f));   //VRBot will face to the 3rd position
        p9sequence.AppendInterval(.5f);  // Delay of .5s
        p9sequence.Append(transform.DOMove(position[8], 1f));  //VRBot will move to the 8th position
        p9sequence.Append(transform.DOMove(position[9], 1f));  //VRBot will move to the 9th position
        p9sequence.AppendCallback(() => RotateVRbot(-6.4f, .3f));   //VRBot will face the player
        p9sequence.AppendInterval(.5f);  // Delay of .5s
        p9sequence.AppendCallback(() => HoverVRbot(true));  // Hover ON
        p9sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active
        p9sequence.AppendCallback(() => PlayVRbotScript3(10)); // s10
        p9sequence.AppendInterval(_AudioMngr.vrBotVoice3[10].length); // Delay
        p9sequence.AppendCallback(() => PlayVRbotScript3(11)); // s11
        p9sequence.AppendInterval(_AudioMngr.vrBotVoice3[11].length); // Delay
        p9sequence.AppendCallback(() => _BoardContent[3].SetActive(true)); // activate board content
        p9sequence.AppendCallback(() => PlayVRbotScript3(12)); // s12
        p9sequence.AppendInterval(_AudioMngr.vrBotVoice3[12].length); // Delay
        p9sequence.AppendCallback(() => PlayVRbotScript3(13)); // s13
        p9sequence.AppendInterval(_AudioMngr.vrBotVoice3[13].length); // Delay
        p9sequence.AppendCallback(() => _HandsMnger.DisableEnableHandsInteraction(true)); // Enable hands interaction 
        p9sequence.Play(); 

    }
    

     // SUBLEVEL 4


    public void p10() //PPE Check sub4
    {
        Sequence p10sequence = DOTween.Sequence().SetId("p10");
        p10sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Panel off
        p10sequence.AppendCallback(() => HoverVRbot(false));// Hover OFF   
        p10sequence.AppendInterval(1.7f);  // Delay
        p10sequence.AppendCallback(() => _doorAnimation.OpenDoor()); // Open PPE room door 
        p10sequence.AppendInterval(.3f);  // Delay 
        p10sequence.Append(transform.DOMove(position[1], 2f));  // VRBot will enter the PPE room
        p10sequence.AppendCallback(() => _doorAnimation.CloseDoor()); // PPE room door will close
        p10sequence.AppendCallback(() => RotateVRbot(360f, 1f)); // VRBot will face the player
        p10sequence.AppendCallback(() => HoverVRbot(true)); // Hover ON
        p10sequence.AppendInterval(1.5f); // Delay of 1.5s
        p10sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active

            // Subtitles starts here

        p10sequence.AppendCallback(() => PlayVRbotScript4(1)); // s1       Subtitle 2 text will be set active
        p10sequence.AppendInterval(_AudioMngr.vrBotVoice4[1].length); // Add delay according to the voice over`s duration
        p10sequence.AppendCallback(() => PlayVRbotScript4(2)); // s2     
        p10sequence.AppendInterval(_AudioMngr.vrBotVoice4[2].length); // Delay
        p10sequence.AppendCallback(() => PlayVRbotScript4(3)); // s3      
        p10sequence.AppendInterval(_AudioMngr.vrBotVoice4[3].length); // Delay
        p10sequence.AppendCallback(() => PlayVRbotScript4(4)); // s4      
        p10sequence.AppendInterval(_AudioMngr.vrBotVoice4[4].length+.5f); // Delay + 3s for a bit pause
        p10sequence.AppendCallback(() => PlayVRbotScript4(5)); // s5      
        p10sequence.AppendInterval(_AudioMngr.vrBotVoice4[5].length); // Delay
        p10sequence.AppendCallback(() => PlayVRbotScript4(6)); // s6      
        p10sequence.AppendInterval(_AudioMngr.vrBotVoice4[6].length); // Delay
        p10sequence.AppendCallback(() => PlayVRbotScript4(7)); // s7      
        p10sequence.Play(); 

    }
    
    public void p11()
    {
        Sequence p11sequence = DOTween.Sequence();
        p11sequence.AppendCallback(() => PlayVRbotScript4(8)); // s8
        p11sequence.AppendInterval(_AudioMngr.vrBotVoice4[8].length); // Delay
        p11sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Subtitle panel will be set inactive
        p11sequence.AppendCallback(() => RotateVRbot(90f, .2f)); // VRBot will face the exit room
        p11sequence.AppendInterval(.3f); // Delay of .3s
        p11sequence.Append(transform.DOMove(position[2], 1.5f)); // VRBot will exit the PPE room
        p11sequence.AppendCallback(() => HoverVRbot(false));  //VRBot`s hover is set inactive
        p11sequence.AppendCallback(() => RotateVRbot(450f, .3f)); 
        p11sequence.AppendCallback(() => RotateVRbot(-90f, .3f));
        p11sequence.AppendCallback(() => HoverVRbot(true)); //Hover ON
        p11sequence.Play(); 

         
        // This sequence triggers if the player entered to the main lab
        Sequence p111sequence = DOTween.Sequence().SetId("p111");
        p111sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active
        p111sequence.AppendCallback(() => PlayVRbotScript4(9)); // s9
        p111sequence.AppendInterval(_AudioMngr.vrBotVoice4[9].length); // Delay
        p111sequence.AppendCallback(() => _Checkpoint.ShowCheckpoint(Checkpoint._CheckpointIndexSub4));  // Show next path
        p111sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Subtitle panel will be set active
        p111sequence.AppendCallback(() => HoverVRbot(false)); //Hover OFF
        p111sequence.AppendCallback(() => RotateVRbot(0f, .2f)); // VRBot will face the laboratory 2 
        p111sequence.Append(transform.DOMove(position[5], 2f)); // VRBot will go to laboratory 2
        p111sequence.AppendCallback(() => _doorAnimation2.OpenDoor2()); // Laboratory 2 door will open
        p111sequence.Append(transform.DOMove(position[10], 1f)); // VRBot will go to laboratory 2
        p111sequence.Append(transform.DOMove(position[11], 1f)); // VRBot will go above the table
        p111sequence.AppendCallback(() => RotateVRbot(-57.58f, .2f)); // VRBot will face the player
        p111sequence.AppendCallback(() => HoverVRbot(true)); //Hover ON
        p111sequence.AppendCallback(() => _GameMngr._doorTrigger2.enabled = true); // Lab 2 door will be enabled
        p111sequence.AppendCallback(() => _Checkpoint.ShowCheckpoint(Checkpoint._CheckpointIndexSub4));  // Show next path 
        p111sequence.Pause(); 
    }

    public void p12()
    {
        Sequence p12sequence = DOTween.Sequence();
        p12sequence.AppendInterval(.5f);  // Delay of .5s
        p12sequence.AppendCallback(() => HoverVRbot(true));  // Hover ON
        p12sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active
        p12sequence.AppendCallback(() => PlayVRbotScript4(10)); // s10
        p12sequence.AppendInterval(_AudioMngr.vrBotVoice4[10].length); // Delay
        p12sequence.AppendCallback(() => PlayVRbotScript4(11)); // s11
        p12sequence.AppendInterval(_AudioMngr.vrBotVoice4[11].length); // Delay
        p12sequence.AppendCallback(() => _BoardContent[4].SetActive(true)); // activate board content
        p12sequence.AppendCallback(() => PlayVRbotScript4(12)); // s12
        p12sequence.AppendInterval(_AudioMngr.vrBotVoice4[12].length); // Delay
        p12sequence.AppendCallback(() => PlayVRbotScript4(13)); // s13
        p12sequence.AppendInterval(_AudioMngr.vrBotVoice4[13].length); // Delay
        p12sequence.AppendCallback(() => _HandsMnger.DisableEnableHandsInteraction(true)); // Enable hands interaction 
        p12sequence.Play(); 

    }
    
    
     // SUBLEVEL 5


    public void p13() //PPE Check sub5
    {
        Sequence p13sequence = DOTween.Sequence().SetId("p13");
        p13sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Panel off
        p13sequence.AppendCallback(() => HoverVRbot(false));// Hover OFF   
        p13sequence.AppendInterval(1.7f);  // Delay
        p13sequence.AppendCallback(() => _doorAnimation.OpenDoor()); // Open PPE room door 
        p13sequence.AppendInterval(.3f);  // Delay 
        p13sequence.Append(transform.DOMove(position[1], 2f));  // VRBot will enter the PPE room
        p13sequence.AppendCallback(() => _doorAnimation.CloseDoor()); // PPE room door will close
        p13sequence.AppendCallback(() => RotateVRbot(360f, 1f)); // VRBot will face the player
        p13sequence.AppendCallback(() => HoverVRbot(true)); // Hover ON
        p13sequence.AppendInterval(1.5f); // Delay of 1.5s
        p13sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active

            // Subtitles starts here

        p13sequence.AppendCallback(() => PlayVRbotScript5(1)); // s1       Subtitle 2 text will be set active
        p13sequence.AppendInterval(_AudioMngr.vrBotVoice5[1].length); // Add delay according to the voice over`s duration
        p13sequence.AppendCallback(() => PlayVRbotScript5(2)); // s2     
        p13sequence.AppendInterval(_AudioMngr.vrBotVoice5[2].length); // Delay
        p13sequence.AppendCallback(() => PlayVRbotScript5(3)); // s3      
        p13sequence.AppendInterval(_AudioMngr.vrBotVoice5[3].length); // Delay
        p13sequence.AppendCallback(() => PlayVRbotScript5(4)); // s4      
        p13sequence.AppendInterval(_AudioMngr.vrBotVoice5[4].length+.5f); // Delay + 3s for a bit pause
        p13sequence.AppendCallback(() => PlayVRbotScript5(5)); // s5      
        p13sequence.AppendInterval(_AudioMngr.vrBotVoice5[5].length); // Delay
        p13sequence.AppendCallback(() => PlayVRbotScript5(6)); // s6      
        p13sequence.AppendInterval(_AudioMngr.vrBotVoice5[6].length); // Delay
        p13sequence.AppendCallback(() => PlayVRbotScript5(7)); // s7      
        p13sequence.Play(); 

    }
    
    public void p14()
    {
        Sequence p14sequence = DOTween.Sequence();
        p14sequence.AppendCallback(() => PlayVRbotScript5(8)); // s8
        p14sequence.AppendInterval(_AudioMngr.vrBotVoice5[8].length); // Delay
        p14sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Subtitle panel will be set inactive
        p14sequence.AppendCallback(() => RotateVRbot(90f, .2f)); // VRBot will face the exit room
        p14sequence.AppendInterval(.3f); // Delay of .3s
        p14sequence.Append(transform.DOMove(position[2], 1.5f)); // VRBot will exit the PPE room
        p14sequence.AppendCallback(() => HoverVRbot(false));  //VRBot`s hover is set inactive
        p14sequence.AppendCallback(() => RotateVRbot(450f, .3f)); 
        p14sequence.AppendCallback(() => RotateVRbot(-90f, .3f));
        p14sequence.AppendCallback(() => HoverVRbot(true)); //Hover ON
        p14sequence.Play(); 

         
        // This sequence triggers if the player entered to the main lab
        Sequence p141sequence = DOTween.Sequence().SetId("p141");
        p141sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active
        p141sequence.AppendCallback(() => PlayVRbotScript5(9)); // s9
        p141sequence.AppendInterval(_AudioMngr.vrBotVoice5[9].length); // Delay
        p141sequence.AppendCallback(() => _Checkpoint.ShowCheckpoint(Checkpoint._CheckpointIndexSub5));  // Show next path
        p141sequence.Pause(); 
    }

    public void p15()
    {
        Sequence p15sequence = DOTween.Sequence();
        p15sequence.AppendCallback(() => _subtitlePanel.SetActive(false)); // Subtitle panel will be set inactive
        p15sequence.AppendCallback(() => HoverVRbot(false)); //Hover OFF 
        p15sequence.AppendCallback(() => RotateVRbot(90f, .3f));   //VRBot will face to the 3rd position
        p15sequence.AppendInterval(.5f);  // Delay of .5s
        p15sequence.Append(transform.DOMove(position[12], 1f));  //VRBot will move to the 9th position
        p15sequence.AppendCallback(() => RotateVRbot(35.44f, .3f));   //VRBot will face the player

        p15sequence.AppendInterval(.5f);  // Delay of .5s
        p15sequence.AppendCallback(() => HoverVRbot(true));  // Hover ON
        p15sequence.AppendCallback(() => _subtitlePanel.SetActive(true)); // Subtitle panel will be set active
        p15sequence.AppendCallback(() => PlayVRbotScript5(10)); // s10
        p15sequence.AppendInterval(_AudioMngr.vrBotVoice5[10].length); // Delay
        p15sequence.AppendCallback(() => PlayVRbotScript5(11)); // s11
        p15sequence.AppendInterval(_AudioMngr.vrBotVoice5[11].length); // Delay
        p15sequence.AppendCallback(() => _BoardContent[5].SetActive(true)); // activate board content
        p15sequence.AppendCallback(() => PlayVRbotScript5(12)); // s12
        p15sequence.AppendInterval(_AudioMngr.vrBotVoice5[12].length); // Delay
        p15sequence.AppendCallback(() => PlayVRbotScript5(13)); // s13
        p15sequence.AppendInterval(_AudioMngr.vrBotVoice5[13].length); // Delay
        p15sequence.AppendCallback(() => _HandsMnger.DisableEnableHandsInteraction(true)); // Enable hands interaction 
        p15sequence.Play(); 
    }
    
    

    // VRBot`s functionalities
    private void HoverVRbot(bool Play)
    {
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = originalPosition + new Vector3(0, hoverHeight, 0);

        if (Play)
        {
            hoverSequence = DOTween.Sequence();
            hoverSequence.Append(transform.DOMove(targetPosition, hoverSpeed).SetEase(Ease.InOutQuad));
            hoverSequence.Append(transform.DOMove(originalPosition, hoverSpeed).SetEase(Ease.InOutQuad));
            hoverSequence.SetLoops(-1);
            hoverSequence.Play();
        }
        else 
        {
            hoverSequence.Kill(); 
        }
    }
    
    private void RotateVRbot(float FaceRotationY, float FRspeed)
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        transform.DORotate(new Vector3(currentRotation.x, FaceRotationY, currentRotation.z), FRspeed, RotateMode.FastBeyond360).SetEase(Ease.Linear);
    }
    
    public void PlayVRbotScript(int currentScript)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() => _subtitles[prevScript].SetActive(false)); // 
        sequence.AppendCallback(() => _subtitles[currentScript].SetActive(true)); // 
        sequence.AppendCallback(() => _AudioMngr.PlaySubtitleVoiceOver(_AudioMngr.vrBotVoice[currentScript])); //
        sequence.AppendCallback(() => prevScript = currentScript); // 
        sequence.AppendCallback(() => currScript = currentScript); // 
        sequence.Play(); 
    }
    
    public void PlayVRbotScript2(int currentScript)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() => _subtitles2[prevScript].SetActive(false)); // 
        sequence.AppendCallback(() => _subtitles2[currentScript].SetActive(true)); // 
        sequence.AppendCallback(() => _AudioMngr.PlaySubtitleVoiceOver(_AudioMngr.vrBotVoice2[currentScript])); //
        sequence.AppendCallback(() => prevScript = currentScript); // 
        sequence.AppendCallback(() => currScript = currentScript); // 
        sequence.Play(); 
    }

    public void PlayVRbotScript3(int currentScript)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() => _subtitles3[prevScript].SetActive(false)); // Change this
        sequence.AppendCallback(() => _subtitles3[currentScript].SetActive(true)); // Change this
        sequence.AppendCallback(() => _AudioMngr.PlaySubtitleVoiceOver(_AudioMngr.vrBotVoice3[currentScript])); // Chnage this
        sequence.AppendCallback(() => prevScript = currentScript); 
        sequence.AppendCallback(() => currScript = currentScript); 
        sequence.Play(); 
    }

    public void PlayVRbotScript4(int currentScript)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() => _subtitles4[prevScript].SetActive(false)); //  Chnage this
        sequence.AppendCallback(() => _subtitles4[currentScript].SetActive(true)); //  Chnage this
        sequence.AppendCallback(() => _AudioMngr.PlaySubtitleVoiceOver(_AudioMngr.vrBotVoice4[currentScript])); // Chnage this
        sequence.AppendCallback(() => prevScript = currentScript); 
        sequence.AppendCallback(() => currScript = currentScript); 
        sequence.Play(); 
    }

    public void PlayVRbotScript5(int currentScript)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() => _subtitles5[prevScript].SetActive(false)); //  Change this
        sequence.AppendCallback(() => _subtitles5[currentScript].SetActive(true)); //  Change this
        sequence.AppendCallback(() => _AudioMngr.PlaySubtitleVoiceOver(_AudioMngr.vrBotVoice5[currentScript])); // Change this
        sequence.AppendCallback(() => prevScript = currentScript); 
        sequence.AppendCallback(() => currScript = currentScript); 
        sequence.Play(); 
    }
    
    public void PlayScritStep(int Scriptt)
    {
        currentStepExecuted = true;
        Sequence step = DOTween.Sequence();
        step.AppendCallback(() => PlayVRbotScript(Scriptt)); //
        step.AppendInterval(_AudioMngr.vrBotVoice[Scriptt].length); // 
        step.Play(); 
        UIMngr.currentProgress += 14f;

    }

    public void PlayScritStep2(int Scriptt) // Change this
    {
        currentStepExecuted2 = true; // Change this; After the first step, you need to copy this and make it false to enable the next step.
        Sequence step = DOTween.Sequence();
        step.AppendCallback(() => PlayVRbotScript2(Scriptt)); // Change this
        step.AppendInterval(_AudioMngr.vrBotVoice2[Scriptt].length); // Change this
        step.Play(); 
        UIMngr.currentProgress2 += 16.66f; // Change this
    }

    public void PlayScritStep3(int Scriptt) // Change this
    {
        currentStepExecuted3 = true; // Change this; After the first step, you need to copy this and make it false to enable the next step.
        Sequence step = DOTween.Sequence();
        step.AppendCallback(() => PlayVRbotScript3(Scriptt)); // Change this
        step.AppendInterval(_AudioMngr.vrBotVoice3[Scriptt].length); // Change this
        step.Play(); 
        UIMngr.currentProgress3 += 16.66f; // Change this
    }

    public void PlayScritStep4(int Scriptt) // Change this
    {
        currentStepExecuted4 = true; // Change this; After the first step, you need to copy this and make it false to enable the next step.
        Sequence step = DOTween.Sequence();
        step.AppendCallback(() => PlayVRbotScript4(Scriptt)); // Change this
        step.AppendInterval(_AudioMngr.vrBotVoice4[Scriptt].length); // Change this
        step.Play(); 
        UIMngr.currentProgress4 += 14f; // Change this
    }

    public void PlayScritStep5(int Scriptt) // Change this
    {
        currentStepExecuted5 = true; // Change this; After the first step, you need to copy this and make it false to enable the next step.
        Sequence step = DOTween.Sequence();
        step.AppendCallback(() => PlayVRbotScript5(Scriptt)); // Change this
        step.AppendInterval(_AudioMngr.vrBotVoice5[Scriptt].length); // Change this
        step.Play(); 
        UIMngr.currentProgress5 += 19.8f; // Change this
    }
    
    public void Sub1ExperimentSteps()
    {
        if(GameMngr.CurrentLevelIndex == 1)
        {
            if(GameMngr.S1currentsteps == 1f && !currentStepExecuted) //Step1
            {
                PlayScritStep(14); 
            }  

            if(GameMngr.S1currentsteps == 2f && !currentStepExecuted) //Step2
            {
                PlayScritStep(15); 
            } 

            if(GameMngr.S1currentsteps == 3f && !currentStepExecuted) //Step3
            {
                PlayScritStep(16); 
            } 

            if(GameMngr.S1currentsteps == 4f && !currentStepExecuted) //Step4
            {
                PlayScritStep(17); 
            } 

            if(GameMngr.S1currentsteps == 5f && !currentStepExecuted) //Step5
            {
                PlayScritStep(18); 
            } 

            if(GameMngr.S1currentsteps == 6f && !currentStepExecuted) //Step6
            {
                GameMngr.S1currentsteps = 7f;
                currentStepExecuted = true;
                GameMngr.alreadyReachLastStep = true;
                UIMngr.currentProgress += 16f;
                ScoreMngr.TotalScore = UIMngr.currentProgress;
                Sequence step = DOTween.Sequence();
                step.AppendCallback(() => PlayVRbotScript(19)); // s19
                step.AppendInterval(_AudioMngr.vrBotVoice[19].length); // Delay
                step.AppendCallback(() => PlayVRbotScript(20)); // s20
                step.AppendInterval(_AudioMngr.vrBotVoice[20].length); // Delay
                step.AppendCallback(() => _ScoreMngr.CheckScore()); // verdict
                step.Play(); 
            } 
        }
    }
    
    public void Sub2ExperimentSteps()
    {
        if(GameMngr.CurrentLevelIndex == 2)
        {
            if(GameMngr.S2currentsteps == 1f && !currentStepExecuted2) //Step1
            {
                PlayScritStep2(14);
            }

            if(GameMngr.S2currentsteps == 2f && !currentStepExecuted2) //Step2
            {
                PlayScritStep2(15); 
            } 

            if(GameMngr.S2currentsteps == 3f && !currentStepExecuted2) //Step3
            {
                PlayScritStep2(16);
            } 

            if(GameMngr.S2currentsteps == 4f && !currentStepExecuted2) //Step4
            {
                PlayScritStep2(17);
            }

            if(GameMngr.S2currentsteps == 5f && !currentStepExecuted2) //Step5
            {
                PlayScritStep2(18);
            }

            if(GameMngr.S2currentsteps == 6f && !currentStepExecuted2) //Step6
            {
                GameMngr.S2currentsteps = 7f; // Change this
                currentStepExecuted2 = true;  // Change this
                GameMngr.alreadyReachLastStep = true;
                UIMngr.currentProgress2 += 16.66f;
                ScoreMngr.TotalScore = UIMngr.currentProgress2;
                Sequence step = DOTween.Sequence();
                step.AppendCallback(() => PlayVRbotScript2(19)); // s19
                step.AppendInterval(_AudioMngr.vrBotVoice2[19].length); // Delay
                step.AppendCallback(() => PlayVRbotScript2(20)); // s20
                step.AppendInterval(_AudioMngr.vrBotVoice2[20].length); // Delay
                step.AppendCallback(() => _ScoreMngr.CheckScore()); // verdict
                step.Play(); 
            }
            // if(GameMngr.S2SpilledChemPowder && !alreadyPlayedSpilledFunction)
            // {
            //     alreadyPlayedSpilledFunction = true;
            //     _AudioMngr.PlayVRBotS2Reactions(_AudioMngr.vrBotReactions[3]); // Oh no you`ve spilled it
            //     _ScoreMngr.CheckScore();
            // }
        }
    }
    
    public void Sub3ExperimentSteps()
    {
        if(GameMngr.CurrentLevelIndex == 3)
        {
            if(GameMngr.S3currentsteps == 1f && !currentStepExecuted3) //Step1
            {
                PlayScritStep3(14);
            }

            if(GameMngr.S3currentsteps == 2f && !currentStepExecuted3) //Step2
            {
                PlayScritStep3(15); 
            } 

            if(GameMngr.S3currentsteps == 3f && !currentStepExecuted3) //Step3
            {
                PlayScritStep3(16);
            } 

            if(GameMngr.S3currentsteps == 4f && !currentStepExecuted3) //Step4
            {
                PlayScritStep3(17);
            }

            if(GameMngr.S3currentsteps == 5f && !currentStepExecuted3) //Step5
            {
                PlayScritStep3(18);
            } 

            if(GameMngr.S3currentsteps == 6f && !currentStepExecuted3) //Step5
            {
                PlayScritStep3(19);
            } 
            if(GameMngr.S3currentsteps == 7f && !currentStepExecuted3) //Step6
            {
                GameMngr.S3currentsteps = 8f; // Change this
                currentStepExecuted3 = true;  // Change this
                GameMngr.alreadyReachLastStep = true;
                UIMngr.currentProgress3 += 16.66f; //Change this
                ScoreMngr.TotalScore = UIMngr.currentProgress3;  //Change this
                Sequence step = DOTween.Sequence();
                step.AppendCallback(() => PlayVRbotScript3(20)); // s19
                step.AppendInterval(_AudioMngr.vrBotVoice3[20].length); // Delay
                step.AppendCallback(() => PlayVRbotScript3(21)); // s20
                step.AppendInterval(_AudioMngr.vrBotVoice3[21].length); // Delay
                step.AppendCallback(() => _ScoreMngr.CheckScore()); // verdict
                step.Play(); 
            }
            // if(GameMngr.S2SpilledChemPowder && !alreadyPlayedSpilledFunction)
            // {
            //     alreadyPlayedSpilledFunction = true;
            //     _AudioMngr.PlayVRBotS2Reactions(_AudioMngr.vrBotReactions[3]); // Oh no you`ve spilled it
            //     _ScoreMngr.CheckScore();
            // }
        }
    }
    
    public void Sub4ExperimentSteps()
    {
        if(GameMngr.CurrentLevelIndex == 4)
        {
            if(GameMngr.S4currentsteps == 1f && !currentStepExecuted4) //Step1
            {
                PlayScritStep4(14);
            }

            if(GameMngr.S4currentsteps == 2f && !currentStepExecuted4) //Step2
            {
                PlayScritStep4(15); 
            } 

            if(GameMngr.S4currentsteps == 3f && !currentStepExecuted4) //Step3
            {
                PlayScritStep4(16);
            } 

            if(GameMngr.S4currentsteps == 4f && !currentStepExecuted4) //Step4
            {
                PlayScritStep4(17);
            }

            if(GameMngr.S4currentsteps == 5f && !currentStepExecuted4) //Step5
            {
                PlayScritStep4(18);
            } 

            if(GameMngr.S4currentsteps == 6f && !currentStepExecuted4) //Step5
            {
                PlayScritStep4(19);
            } 
            if(GameMngr.S4currentsteps == 7f && !currentStepExecuted4) //Step6
            {
                GameMngr.S4currentsteps = 8f; // Change this
                currentStepExecuted4 = true;  // Change this
                GameMngr.alreadyReachLastStep = true;
                UIMngr.currentProgress4 += 16f; //Change this
                ScoreMngr.TotalScore = UIMngr.currentProgress4;  //Change this
                Sequence step = DOTween.Sequence();
                step.AppendCallback(() => PlayVRbotScript4(20)); // s20
                step.AppendInterval(_AudioMngr.vrBotVoice4[20].length); // Delay
                step.AppendCallback(() => _AudioMngr.PlayVRBotChemReactions(_AudioMngr.vrBotReactions4[0])); // reactions 
                step.AppendInterval(_AudioMngr.vrBotReactions4[0].length); // Delay
                step.AppendCallback(() => _AudioMngr.PlayVRBotChemReactions(_AudioMngr.vrBotReactions4[1])); // reactions 
                step.AppendInterval(_AudioMngr.vrBotReactions4[1].length); // Delay
                step.AppendCallback(() => _AudioMngr.PlayVRBotChemReactions(_AudioMngr.vrBotReactions4[2])); // reactions 
                step.AppendInterval(_AudioMngr.vrBotReactions4[2].length); // Delay
                step.AppendCallback(() => _AudioMngr.PlayVRBotChemReactions(_AudioMngr.vrBotReactions4[3])); // reactions 
                step.AppendInterval(_AudioMngr.vrBotReactions4[3].length); // Delay
                step.AppendCallback(() => _AudioMngr.PlayVRBotChemReactions(_AudioMngr.vrBotReactions4[4])); // reactions 
                step.AppendInterval(_AudioMngr.vrBotReactions4[4].length); // Delay
                step.AppendCallback(() => _AudioMngr.PlayVRBotChemReactions(_AudioMngr.vrBotReactions4[5])); // reactions 
                step.AppendInterval(_AudioMngr.vrBotReactions4[5].length); // Delay
                step.AppendCallback(() => _ScoreMngr.CheckScore()); // verdict
                step.Play(); 
            }
            // if(GameMngr.S2SpilledChemPowder && !alreadyPlayedSpilledFunction)
            // {
            //     alreadyPlayedSpilledFunction = true;
            //     _AudioMngr.PlayVRBotS2Reactions(_AudioMngr.vrBotReactions[3]); // Oh no you`ve spilled it
            //     _ScoreMngr.CheckScore();
            // }
        }
    }
    
    public void Sub5ExperimentSteps()
    {
        if(GameMngr.CurrentLevelIndex == 5)
        {
            if(GameMngr.S5currentsteps == 1f && !currentStepExecuted5) //Step1
            {
                PlayScritStep5(14);
            }

            if(GameMngr.S5currentsteps == 2f && !currentStepExecuted5) //Step2
            {
                PlayScritStep5(15); 
            } 

            if(GameMngr.S5currentsteps == 3f && !currentStepExecuted5) //Step3
            {
                PlayScritStep5(16);
            } 

            if(GameMngr.S5currentsteps == 4f && !currentStepExecuted5) //Step4
            {
                PlayScritStep5(17);
            }

            if(GameMngr.S5currentsteps == 5f && !currentStepExecuted5) //Step5
            {
                GameMngr.S5currentsteps = 6f; // Change this
                currentStepExecuted5 = true;  // Change this
                GameMngr.alreadyReachLastStep = true;
                UIMngr.currentProgress5 += 19.8f; //Change this
                ScoreMngr.TotalScore = UIMngr.currentProgress5;  //Change this
                Sequence step = DOTween.Sequence();
                step.AppendCallback(() => PlayVRbotScript5(18)); // s19
                step.AppendInterval(_AudioMngr.vrBotVoice5[18].length); // Delay
                step.AppendCallback(() => PlayVRbotScript5(19)); // s20
                step.AppendInterval(_AudioMngr.vrBotVoice5[19].length); // Delay
                step.AppendCallback(() => _ScoreMngr.CheckScore()); // verdict
                step.Play(); 
            }
            // if(GameMngr.S2SpilledChemPowder && !alreadyPlayedSpilledFunction)
            // {
            //     alreadyPlayedSpilledFunction = true;
            //     _AudioMngr.PlayVRBotS2Reactions(_AudioMngr.vrBotReactions[3]); // Oh no you`ve spilled it
            //     _ScoreMngr.CheckScore();
            // }
        }
    }

}