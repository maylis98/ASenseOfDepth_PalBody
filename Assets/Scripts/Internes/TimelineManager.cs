using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    private bool gameIsStarted;
    private PlayableDirector timelineStartGame;
    public AudioSource gameAudio;
    void Start()
    {
        timelineStartGame = GetComponent<PlayableDirector>();
        gameIsStarted = false;
        EventManager.StartListening("StartGame", startGameTimeline);
    }

    public void startGameTimeline(object data)
    {

        if(gameIsStarted =(bool)data)
        {
            timelineStartGame.Play();
        }
    }

    public void endGameTimeline()
    {
        timelineStartGame.Stop();
        gameAudio.Play();
    }

}
