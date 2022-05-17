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
        soundHeartBeat.volumeLevel = 0.6f;
        soundBreath.volumeLevel = 0.5f;
        soundWater.volumeLevel = 1f;
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

    public void IsStressed()
    {
        StartCoroutine(stressCurve());
        //waterPresence();

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

    IEnumerator stressCurve()
    {
        soundHeartBeat.iCurrentClip = 2;
        soundHeartBeat.volumeLevel = 1f;

        yield return new WaitForSeconds(3);

        soundHeartBeat.iCurrentClip = 4;

        yield return new WaitForSeconds(3);

        soundHeartBeat.iCurrentClip = 6;

        yield return new WaitForSeconds(10);

        soundHeartBeat.iCurrentClip = 4;

        yield return new WaitForSeconds(5);

        soundHeartBeat.iCurrentClip = 2;

        yield return new WaitForSeconds(5);

        soundHeartBeat.iCurrentClip = 1;
        soundHeartBeat.volumeLevel = 0.6f;

    }

    IEnumerator waterRising()
    {
        soundWater.iCurrentClip = 1;
        soundHeartBeat.iCurrentClip = 5;

        yield return new WaitForSeconds(5);

        soundHeartBeat.iCurrentClip = 1;

        yield return new WaitForSeconds(25);

        soundWater.iCurrentClip = 0;
        soundHeartBeat.iCurrentClip = -1;
    }

    IEnumerator stopWaterPresence()
    {
        yield return new WaitForSeconds(130);

        soundWater.iCurrentClip = -1;

    }



}
