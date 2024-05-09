using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPE : MonoBehaviour
{
    [SerializeField] GameObject Labcoat;
    [SerializeField] GameObject Right_hand;
    [SerializeField] GameObject Right_glove;
    [SerializeField] GameObject Left_hand;
    [SerializeField] GameObject Left_glove;
    [SerializeField] GameObject Goggles;
    public Material glovesMat;
    private Renderer rendererRG; 
    private Renderer rendererLG; 
    private bool nextstationReady = false;
    private bool gogglesReady = false;
    private bool rightGReady = false;
    private bool leftGReady = false;
    private bool coatReady = false;

    private void Start() 
    {
        rendererRG = Right_hand.GetComponent<Renderer>();
        rendererLG = Left_hand.GetComponent<Renderer>();
    }

    private void Update() 
    {
        if(gogglesReady && rightGReady && leftGReady && coatReady && !nextstationReady)
        {
            nextstationReady = true;
            GameMngr.ppe_ready = true;
        }
    }

    public void WearLabcoat()
    {
        coatReady = true;
        Labcoat.SetActive(false);
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

    public void WearGoggles()
    {
        gogglesReady = true;
        Goggles.SetActive(false);
    }
}
