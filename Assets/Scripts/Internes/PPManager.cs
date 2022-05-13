using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PPManager : MonoBehaviour
{
    public VolumeProfile PP;
    private Vignette focusVignette;
    public float duration;
    private float currentValue;
    private float focusValue = 0.6f;
    private float initialValue = 0f;

    private void Awake()
    {
       //PP = GetComponent<V>();
        currentValue = initialValue;

        PP.TryGet<Vignette>(out focusVignette);
        focusVignette.intensity.value = currentValue;
        
    }
    public void Vignettage()
    {
        StartCoroutine(focusVignettage(focusValue, duration));
    }

    public void exitVignettage()
    {
        StartCoroutine(focusVignettage(initialValue, duration));
        currentValue = initialValue;
    }

    IEnumerator focusVignettage(float endValue, float durationFade)
    {
        float time = 0;
        float startValue = currentValue;
        while (time < durationFade)
        {
            currentValue = Mathf.Lerp(startValue, endValue, time / durationFade);
            time += Time.deltaTime;
            focusVignette.intensity.value = currentValue;
            yield return null;
        }

    }
}
