using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Animator canvasA;
    public Animator palBody;
    public Animator fadeIn;


    public void showPalBody() 
    {
        StartCoroutine(timelineAppear());
    }

    IEnumerator timelineAppear()
    {
        palBody.SetBool("goingUp", true);
        canvasA.SetBool("load", true);

        yield return new WaitForSeconds(5);

        fadeIn.SetBool("appear", true);
    }
}
