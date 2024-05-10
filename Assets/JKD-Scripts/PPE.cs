using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPE : MonoBehaviour
{
    public GameObject Labcoat;
    public GameObject Right_hand;
    public GameObject Right_glove;
    public GameObject Left_hand;
    public GameObject Left_glove;
    public GameObject Goggles;
    public Material glovesMat;
    private Renderer rendererRG; 
    private Renderer rendererLG; 
    private bool nextstationReady = false;
    public static bool gogglesReady = false;
    private bool rightGReady = false;
    private bool leftGReady = false;
    public static bool coatReady = false;
    

    private void Start() 
    {
        gogglesReady = false;
        rightGReady = false;
        leftGReady = false;
        coatReady = false;
        rendererRG = Right_hand.GetComponent<Renderer>();
        rendererLG = Left_hand.GetComponent<Renderer>();
    }

    private void Update() 
    {
        if(gogglesReady && rightGReady && leftGReady && coatReady && !nextstationReady)
        {
            // Debug.Log("PEE READY");
            nextstationReady = true;
            GameMngr.ppe_ready = true;
        }
    }

    public void WearRightGlove()
    {
        rightGReady = true;
        rendererRG.material = glovesMat;
        Right_glove.SetActive(false);
    }

    public void WearLeftGlove()
    {
        leftGReady = true;
        rendererLG.material = glovesMat;
        Left_glove.SetActive(false);
    }
}
