using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Animator characterAnimator;
    public GameObject veil;
    public GameObject body;
    public Material veilNewMaterial;

    private SkinnedMeshRenderer veilRenderer;
    private Material veilMaterial;
    private Material bodyMaterial;
    //public SkinnedMeshRenderer veilMesh;
    private bool IsBlinking;

    [SerializeField]
    private Color colorToChange;
    [SerializeField]
    private Color blinkingColor;
    [SerializeField]
    private Color endColor;
    [SerializeField]
    private Color startColorA;
    [SerializeField]
    private Color endColorA;
    [SerializeField]
    private float timeVeilDisappear;
    [SerializeField]
    private float timeBodyAppear;



    private void Start()
    {
        IsBlinking = false;

        veilRenderer = veil.GetComponent<SkinnedMeshRenderer>();
        veilMaterial = veil.GetComponent<Renderer>().sharedMaterial;
        bodyMaterial = body.GetComponent<Renderer>().sharedMaterial;
        veilNewMaterial.color = colorToChange;
        bodyMaterial.SetColor("_Color_A", startColorA);
    }

    public void IsScared()
    {
        characterAnimator.SetBool("scared", true);
    }

    public void IsNotScared()
    {
        characterAnimator.SetBool("scared", false);
    }

    public void IsSurprised()
    {
        characterAnimator.SetBool("isSurprised", true);
    }


    public void IsNotSurprised()
    {
        characterAnimator.SetBool("isSurprised", false);
    }



    public void LookAround()
    {
        characterAnimator.SetBool("lookaround", true);
    }

    public void endLookAround()
    {
        characterAnimator.SetBool("lookaround", false);
    }

    public void startBlinking()
    {
        StartCoroutine(blinkingManager());
    }


    private IEnumerator blinkingManager()
    {
        IsBlinking = true;

        if (IsBlinking)
        {
            InvokeRepeating("Blink", 0, 0.2f);
        }

        yield return new WaitForSeconds(3);
        veilMaterial.color = colorToChange;
        IsBlinking = false;
        CancelInvoke("Blink");
        StopAllCoroutines();
    }

    private void Blink()
    {
        if (veilMaterial.color == blinkingColor)
        {
            veilMaterial.color = colorToChange;
        }

        else if (veilMaterial.color == colorToChange)
        {
            veilMaterial.color = blinkingColor;
        }
        else
        {
            veilMaterial.color = colorToChange;
        }
    }

    public void veilDisappearBodyAppear()
    {
        veilRenderer.material = veilNewMaterial;
        StartCoroutine(LerpVeilColor(endColor, timeVeilDisappear));
        StartCoroutine(LerpBodyGradient(endColorA, timeBodyAppear));
    }



    IEnumerator LerpVeilColor(Color targetColor, float duration)
    {
        float time = 0;
        Color startColor = veilNewMaterial.color;
        while (time < duration)
        {
            veilNewMaterial.color = Color.Lerp(startColor, targetColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        veilNewMaterial.color = targetColor;
    }

    IEnumerator LerpBodyGradient(Color endColor, float durationFade)
    {
        float time = 0;
        Color startValue = startColorA;
        while (time < durationFade)
        {
            startColorA = Color.Lerp(startValue, endColor, time / durationFade);
            time += Time.deltaTime;
            bodyMaterial.SetColor("_Color_A", startColorA);
            yield return null;
        } 

    }
}
