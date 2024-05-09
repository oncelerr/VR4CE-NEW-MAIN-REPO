using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlaySteps : MonoBehaviour
{

    public string directorName;

    private PlayableDirector director;

    public GameManager gamemanager;

    public List<Step> steps;

    

    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.Find(directorName).GetComponent<PlayableDirector>();
    }

    [System.Serializable]
    public class Step
    {
        public string name;
        public float time;
        public bool hasPlayed = false;
    }

    public void PlayStepIndex(int index)
    {
        Step step = steps[index];

        if (!step.hasPlayed)
        {
            step.hasPlayed = true;

            director.Stop();
            director.time = step.time;
            director.Play();

            gamemanager.IncrementUniversalScore();
            Debug.Log(gamemanager.GetUniversalScore());
        }
    }
}
