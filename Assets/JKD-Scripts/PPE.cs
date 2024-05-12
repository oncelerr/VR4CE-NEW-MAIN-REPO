using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPE : MonoBehaviour
{
    public GameObject[] PPEChecklist;
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
    public static int PPEclist;

    private void Start() 
    {
        PPEclist = 0;
        gogglesReady = false;
        rightGReady = false;
        leftGReady = false;
        coatReady = false;
        nextstationReady = false;
        GameMngr.ppe_ready = false;
        rendererRG = Right_hand.GetComponent<Renderer>();
        rendererLG = Left_hand.GetComponent<Renderer>();
    }

    private void Update() 
    {
        PPEChecklist[PPEclist].SetActive(true);
        if (PPEclist == 0)
        {
            for (int i = 0; i < PPEChecklist.Length; i++)
            {
                PPEChecklist[i].SetActive(false);
            }
        }
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
        PPEclist = 2;
    }

    public void WearLeftGlove()
    {
        PPEclist = 2;
        leftGReady = true;
        rendererLG.material = glovesMat;
        Left_glove.SetActive(false);
    }
}
