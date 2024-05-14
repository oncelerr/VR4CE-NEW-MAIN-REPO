using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class TriggerZone : MonoBehaviour
{
    public string targetTag;
    public bool isToggled = false;
    public PlayableDirector timeline;
    public Canvas canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            if (!isToggled)
            {
                canvas.gameObject.SetActive(true);
                isToggled = true;
                timeline.Pause();
            }
            else
            {
                canvas.gameObject.SetActive(false);
                isToggled = false;
                timeline.Resume();
            }
        }
    }
}
