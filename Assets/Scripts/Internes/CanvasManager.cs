using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CanvasManager : MonoBehaviour
{

    public PlayableDirector canvasTimeline; 


    public void startTimeline()
    {
        canvasTimeline.Play();
    }

    public void endTimeline()
    {
        canvasTimeline.Stop();
    }



}
