using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CanvasManager : MonoBehaviour
{
    public PlayableDirector canvasStartTimeline;
    public PlayableDirector canvasCloseTimeline;

    private void Start()
    {
        EventManager.StartListening("CloseMemory", endTimeline);
    }

    public void startTimeline()
    {
        canvasStartTimeline.enabled = true;
        canvasStartTimeline.Play();
    }

    public void pauseTimeline()
    {
        canvasStartTimeline.Pause();
    }
    public void endTimeline(object data)
    {
        if((bool)data)
        {
            //canvasStartTimeline.Stop();
            canvasStartTimeline.enabled = false;
            canvasCloseTimeline.Play();
        }
        
    }

}
