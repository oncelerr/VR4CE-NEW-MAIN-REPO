using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class TriggerZone : MonoBehaviour
{
    public string targetTag;
    public List<GameObject> canvas;
    public PlayableDirector timeline;
    public bool isToggled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            if (!isToggled)
            {
                foreach (GameObject obj in canvas)
                {
                    obj.SetActive(true);
                }
                isToggled = true;
                timeline.Pause();
            }
            else
            {
                foreach (GameObject obj in canvas)
                {
                    obj.SetActive(false);
                }
                isToggled = false;
                timeline.Resume();
            }
        }
    }
}

