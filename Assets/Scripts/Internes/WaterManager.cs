using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public float currentWaterLevel;
    public float highLevel;
    public float lowLevel;
    public float duration;

    private Animator waterAnimator;

    private void Awake()
    {
        waterAnimator = GetComponent<Animator>();
        currentWaterLevel = lowLevel;
        this.transform.position = new Vector3(this.transform.position.x, currentWaterLevel, this.transform.position.z);

    }

    public void WaterGoUp()
   {
        StartCoroutine(LerpWater(highLevel, duration));
       //waterAnimator.SetBool("waterUp", true);
   }

    public void WaterGoDown()
    {
        StartCoroutine(LerpWater(lowLevel, duration));
        FindObjectOfType<NativeWebsocketChat>().SendChatMessage("water down");
        //waterAnimator.SetBool("waterUp", false);
    }

    IEnumerator LerpWater(float endPos, float durationFade)
    {
        float time = 0;
        float startValue = currentWaterLevel;
        while (time < durationFade)
        {
            currentWaterLevel = Mathf.Lerp(startValue, endPos, time / durationFade);
            time += Time.deltaTime;
            this.transform.position = new Vector3(this.transform.position.x, currentWaterLevel, this.transform.position.z);
            FindObjectOfType<ProgressBar>().GetCurrentFill(currentWaterLevel, lowLevel, highLevel);
            yield return null;
        }

    }


}
