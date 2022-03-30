using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    public GameObject intro;
    public GameObject endCanvas;

    public Animator dialogueBoxAnimator;

    private Queue<string> sentences;

    void Start()
    {
        endCanvas.SetActive(false);
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialog dialogue)
    {
        dialogueBoxAnimator.SetBool("isOpen", true);
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //dialogueText.text = sentence;
      

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

   void EndDialogue()
    {
        intro.SetActive(false);
        dialogueBoxAnimator.SetBool("isOpen", false);

        Debug.Log("End of conversation");
        endCanvas.SetActive(true);
    }

    
}
