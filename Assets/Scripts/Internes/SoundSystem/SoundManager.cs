using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoundManager : MonoBehaviour
{
    public Sound[] soundType;
    public AudioSource audioHeartBeat;
    public AudioSource audioBreath;
    public AudioSource audioWater;
    public void StartSound()
    {
        //if player trigger gate[0]{

        audioBreath.clip = soundType[0].audioClips[0];
    }

    
   private void EndSound()
   {
            
   }


}
