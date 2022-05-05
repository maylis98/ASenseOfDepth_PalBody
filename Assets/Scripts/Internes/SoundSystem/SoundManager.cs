using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoundManager : MonoBehaviour
{
    //public MultiSound[] soundType;
    public MultiSound soundHeartBeat;
    public MultiSound soundBreath;
    public MultiSound soundWater;

    private void Start()
    {
        boxIsTrigger(false);
    }

    public void boxIsTrigger(bool IsTrigger)
    {
        if(IsTrigger == true)
        {
            eventWaterRising(true);
        }
    }

    public void eventWaterRising(bool changeSound)
    {
        StartCoroutine(waterRising());

        if(changeSound == true)
        {
            StopAllCoroutines();
            touchedBox();
        }

    }

    public void touchedBox()
    {
        soundHeartBeat.iCurrentClip = 6;
        soundWater.iCurrentClip = -1;

    }

    public void heartbeatReturnToDefault()
    {
        soundHeartBeat.iCurrentClip = -1;
    }

    public void waterPresence()
    {
        soundWater.iCurrentClip = 2;

        StartCoroutine(stopWaterPresence());
    }

    public void calmWater()
    {
        soundWater.iCurrentClip = -1;
    }

    IEnumerator waterRising()
    {
        soundWater.iCurrentClip = 1;
        soundHeartBeat.iCurrentClip = 5;

        yield return new WaitForSeconds(5);

        soundHeartBeat.iCurrentClip = 0;

        yield return new WaitForSeconds(25);

        soundWater.iCurrentClip = 0;
    }

    IEnumerator stopWaterPresence()
    {
        yield return new WaitForSeconds(130);

        soundWater.iCurrentClip = -1;

    }



}
