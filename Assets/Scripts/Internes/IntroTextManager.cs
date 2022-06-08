using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntroTextManager : MonoBehaviour
{
    public GameObject[] sentences;
    public UnityEvent loadMain;
    private Animator sentenceA;


    public void showText(int indexOf)
    {
        sentenceA = sentences[indexOf].GetComponent<Animator>();
        sentenceA.SetBool("appear", true);
    }

    public void hideText(int indexOf)
    {
        sentenceA = sentences[indexOf].GetComponent<Animator>();
        sentenceA.SetBool("appear", false);

        if(indexOf == 1)
        {
            StartCoroutine(loadMainScene());
        }
    }

    IEnumerator loadMainScene()
    {
        yield return new WaitForSeconds(1);

        loadMain.Invoke();
    }
}
