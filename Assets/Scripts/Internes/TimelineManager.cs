using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    private bool gameIsStarted;

    public PlayableDirector[] timelines;
    public AudioSource gameAudio;

    void Start()
    {
    }

    public void startTimeline(int indexTimelineToStart)
    {
        timelines[indexTimelineToStart].Play();
    }

    public void endTimeline(int indexTimelineToStop)
    {
        timelines[indexTimelineToStop].Stop();

        if(indexTimelineToStop == 1)
        {
            gameAudio.Play();
        }
    }

}
