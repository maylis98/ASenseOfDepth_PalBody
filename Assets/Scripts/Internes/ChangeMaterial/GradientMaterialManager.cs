using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientMaterialManager : MonoBehaviour
{
    public float valueToChange;
    public float targetValue;
    public float transitionTime;
   
    private Material objMaterial;
    private void Start()
    {
        objMaterial = GetComponent<Renderer>().sharedMaterial;
        objMaterial.SetFloat("_BlendHeight", valueToChange);

    }

    public void changeMaterial()
    {
        StartCoroutine(LerpFunction(targetValue, transitionTime));
    }

    IEnumerator LerpFunction(float endValue, float duration)
    {
        float time = 0;
        float startValue = valueToChange;
        while (time < duration)
        {
            valueToChange = Mathf.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            objMaterial.SetFloat("_BlendHeight", valueToChange);
            yield return null;
        }
        valueToChange = endValue;

        
    }
}


