using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradientMaterialManager : MonoBehaviour
{
    public float valueToChange;
    public float targetValue;
    public float initialValue;
    public float transitionTime;

    [SerializeField]
    private Color colorToChange;
    [SerializeField]
    private Color targetColor;
    [SerializeField]
    private Color initialColor;
    public float timeToFade;

    private Material objMaterial;
    private void Start()
    {
        objMaterial = GetComponent<Renderer>().sharedMaterial;
        objMaterial.SetColor("_Color_B", colorToChange);
        objMaterial.SetFloat("_BlendHeight", valueToChange);


    }

    public void changeMaterialAlpha()
    {
        StartCoroutine(LerpMaterialWithAlpha(targetValue, transitionTime));
    }

    public void changeMaterial()
    {
        StartCoroutine(LerpMaterial(targetValue, transitionTime));
    }

    public void changeMaterialColor()
    {
        StartCoroutine(LerpAlpha(targetColor, timeToFade));
    }


    IEnumerator LerpMaterial(float endValue, float duration)
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

    }

    IEnumerator LerpMaterialWithAlpha(float endValue, float duration)
    {
        float time = 0;
        float startValue = valueToChange;
        while (time < duration)
        {
            valueToChange = Mathf.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            objMaterial.SetFloat("_BlendHeight", valueToChange);
            yield return null;

            StartCoroutine(LerpAlpha(targetColor, timeToFade));
        }
       
        
    }

    IEnumerator LerpAlpha(Color endColor, float durationFade)
    {
        float time = 0;
        Color startValue = colorToChange;
        while (time < durationFade)
        {
            colorToChange = Color.Lerp(startValue, endColor, time / durationFade);
            time += Time.deltaTime;
            objMaterial.SetColor("_Color_B", colorToChange);
            yield return null;
        }


        if(this.gameObject.tag == "Gate")
        {
            yield return new WaitForSeconds(10);
            colorToChange = initialColor;
            valueToChange = initialValue;
            objMaterial.SetFloat("_BlendHeight", valueToChange);
            objMaterial.SetColor("_Color_B", colorToChange);
            Debug.Log("color changed");
        }
   
    }
}


