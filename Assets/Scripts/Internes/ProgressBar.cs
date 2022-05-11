using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ProgressBar : MonoBehaviour
{
    /*public int minimum;
    public int maximum;
    public int current;*/
    public Image mask;
    public Image fill;
    public Color colorOfBar;
    private CanvasGroup canvasGroup;
    public float transitionTime;

    private float valueToChange;
 

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //GetCurrentFill();
    }

    public void GetCurrentFill(float current, float minimum, float maximum)
    {

        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;

        mask.fillAmount = fillAmount;

        fill.color = colorOfBar;

        if (canvasGroup.alpha < 1 && currentOffset > 0.05)
        {
            StartCoroutine(fadeAway(1, transitionTime));
        }

        if (currentOffset < 0.1)
        {
            valueToChange = canvasGroup.alpha;
            StartCoroutine(fadeAway(0, transitionTime));
        }
    }

    public void progressBarAppear()
    {
        StartCoroutine(fadeAway(1,transitionTime));
    }
    IEnumerator fadeAway(float endValue, float duration)
    {

        float time = 0;
        float startValue = valueToChange;
        while (time < duration)
        {
            valueToChange = Mathf.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;

            canvasGroup.alpha = valueToChange;
            yield return null;
        }

    }

}
