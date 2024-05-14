using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class gameOverScript : MonoBehaviour
{
    public PlayableDirector timeline;
    public timescript timescript;
    public AudioClip vrBotGameOverVoice;
    public GameObject xrOriginRig;
    public GameObject gameOverCanvas;
    private bool isExecuted = false;

    private void Update()
    {
        if (GameManager.universalScore < 0 && !isExecuted)
        {
            timeline.Stop();
            timescript.StopTimer();
            gameOverCanvas.SetActive(true);

            if (xrOriginRig != null)
            {
                Vector3 position = xrOriginRig.transform.position;
                AudioSource.PlayClipAtPoint(vrBotGameOverVoice, position);
            }
            else
            {
                Debug.LogWarning("XR Origin Rig GameObject is not assigned.");
            }

            isExecuted = true;
        }
    }
}

