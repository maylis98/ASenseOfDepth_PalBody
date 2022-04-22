using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Animator characterAnimator;
    public SkinnedMeshRenderer veilMesh;
    private bool IsBlinking;

    private void Start()
    {
        IsBlinking = false;
    }

    public void IsScared()
    {
        characterAnimator.SetBool("scared", true);
    }

    public void IsNotScared()
    {
        characterAnimator.SetBool("scared", false);
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
        veilMesh.enabled = true;
        IsBlinking = false;
        CancelInvoke("Blink");
        StopAllCoroutines();
    }

    private void Blink()
    {
        if (veilMesh.enabled == false)
        {
            veilMesh.enabled = true;
        }

        else
        {
            veilMesh.enabled = false;
        }
    }

}
