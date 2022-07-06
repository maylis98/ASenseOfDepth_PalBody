using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer vPlayer;
    public GameObject videoText;
    public AudioSource breathAudio;
    // Start is called before the first frame update
    void Start()
    {
        videoText.SetActive(false);
        vPlayer.Stop();
        breathAudio.mute = false;
    }

    public void showVideo()
    {
        videoText.SetActive(true);

        if (vPlayer.isPlaying)
        {
            vPlayer.Stop();
            breathAudio.mute = false;
        }
        else
        {
            vPlayer.Play();
            breathAudio.mute = true;
        }

    }

    public void StopVideo()
    {
        vPlayer.Stop();
        videoText.SetActive(false);
        breathAudio.mute = false;
    }
}
