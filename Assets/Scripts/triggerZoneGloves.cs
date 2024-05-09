using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class triggerZoneGloves : MonoBehaviour
{
    public string targetTag;
    public UnityEvent<GameObject> OnEnterEvent;
    public Material newMaterial; // Reference to the new material to be applied
    private bool done = false;
    public AudioClip audioClip;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public PlayableDirector timeline;
    bool stepZeroPlayed = true;
    bool stepOnePlayed = true;
    public GameObject origSub;
    public GameObject origSub1;
    public GameObject newSub;
    public GameObject newSub1;

    private void OnTriggerEnter(Collider other)
    {
        var otherScript = timeline.GetComponent<PlaySteps>();

        if (otherScript != null)
        {
            stepZeroPlayed = otherScript.steps[0].hasPlayed;
            stepOnePlayed = otherScript.steps[1].hasPlayed;
        }

        Debug.Log(other.gameObject.tag);

        if (other.gameObject.CompareTag(targetTag) && !done)
        {
            OnEnterEvent.Invoke(other.gameObject);
            done = true;
        }
        else
        {
            if (!stepZeroPlayed)
            {
                stepOnePlayed = true;

                if (other.gameObject.CompareTag("labcoat"))
                {
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
                }
                if (other.gameObject.CompareTag("goggles"))
                {
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
                }
            }
            if (!stepOnePlayed)
            {
                if (other.gameObject.CompareTag("goggles"))
                {
                    AudioSource.PlayClipAtPoint(audioClip3, transform.position);
                }
            }
        }
    }

    // Method to change the material of the collided GameObject
    public void ChangeMaterial(GameObject obj)
    {
        Renderer rend = obj.GetComponent<Renderer>();
        if (rend != null && newMaterial != null)
        {
            rend.material = newMaterial;
        }
    }
}
