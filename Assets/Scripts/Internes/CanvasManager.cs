using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CanvasManager : MonoBehaviour
{
    private bool closeMemory;
    public PlayableDirector canvasStartTimeline;
    public PlayableDirector canvasCloseTimeline;

    private void Start()
    {
        closeMemory = false;
        EventManager.StartListening("CloseMemory", endTimeline);
    }

    public void startTimeline()
    {
        canvasStartTimeline.Play();
    }

    public void endTimeline(object data)
    {
        if(closeMemory = (bool)data)
        {
            canvasStartTimeline.Stop();
            canvasCloseTimeline.Play();
        }
        
    }



}
