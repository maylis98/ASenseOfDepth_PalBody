using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    public GameObject textBox;
    public Animator textAnimator;

    void Start()
    {
        textMesh = textBox.GetComponent<TextMeshProUGUI>();
        textAnimator = textBox.GetComponent<Animator>();

        startText();
        textMesh.text = "..Wow, what a fancy way to appear !";
        StartCoroutine(delete());
       
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("LookAround"))
        {
            StartCoroutine(lookAround());

        }

        if (other.CompareTag("WalkFew"))
        {
            StartCoroutine(walkFewSteps());

        }

        if (other.CompareTag("LookDown"))
        {
            
            StartCoroutine(lookDown());

        }

        if (other.CompareTag("LookAround2"))
        {
            FindObjectOfType<AudioManager>().Play("textAppear");
            StartCoroutine(lookAround2());

        }

        if (other.CompareTag("Front Stairs"))
        {
            FindObjectOfType<AudioManager>().Play("textAppear");
            StartCoroutine(frontStairs());

        }

        if (other.CompareTag("Cant Jump"))
        {
            FindObjectOfType<AudioManager>().Play("textAppear");
            StartCoroutine(cantJump());

        }

        if (other.CompareTag("LosyPlace"))
        {
            FindObjectOfType<AudioManager>().Play("textAppear");
            StartCoroutine(losyPlace());

        }

        if (other.CompareTag("WaterRises"))
        {
            FindObjectOfType<AudioManager>().Play("textAppear");
            StartCoroutine(waterRises());

        }
    }

    IEnumerator lookAround()
    {
        yield return new WaitForSeconds(1);

        startText();
        textMesh.text = "What is this place ?";
        StartCoroutine(delete());

    }

    IEnumerator walkFewSteps()
    {
        yield return new WaitForSeconds(3);

        startText();
        textMesh.text = "...at least I'm not stuck in it...";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "There's probably a way out...";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);
        textMesh.text = "...I hope";


        StartCoroutine(delete());

    }

    IEnumerator lookDown()
    {
        yield return new WaitForSeconds(1);

        startText();
        textMesh.text = "...strange feets...";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "...as if I was anchored to the ground...";

        StartCoroutine(delete());


    }

    IEnumerator lookAround2()
    {
        yield return new WaitForSeconds(1);

        startText();
        textMesh.text = "Let's keep walking ... while we can";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "This place is truly desterted...";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "...I wonder what happened";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "...I mean...";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "Why am I here in the first place ? ...";

        StartCoroutine(delete());

    }

    IEnumerator frontStairs()
    {
        yield return new WaitForSeconds(1);

        startText();
        textMesh.text = "Ah... typical platform for jump";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "...to avoid...";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "...water...";

        StartCoroutine(delete());

    }

    IEnumerator cantJump()
    {
        yield return new WaitForSeconds(1);

        startText();
        textMesh.text = "Wait...what ?";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "I can't jump properly !";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "I can't avoid water !";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "Ok well... let's try those stairs...";

        StartCoroutine(delete());

    }

    IEnumerator losyPlace()
    {
        yield return new WaitForSeconds(1);

        startText();
        textMesh.text = "Who put me in this lame place ?!";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "...with...";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "...water...";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "...I really don't like it...";


        StartCoroutine(delete());

    }

    IEnumerator waterRises()
    {
        yield return new WaitForSeconds(2);

        startText();
        textMesh.text = "Oh no...";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "What is happening ?";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "...I'm gonna drown !";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "...I can't run !";

        StartCoroutine(transitionText());
        yield return new WaitForSeconds(3);

        textMesh.text = "...I can't jump !";


        StartCoroutine(delete());

    }

    //Settings functions

    IEnumerator delete()
    {
        yield return new WaitForSeconds(2);
        textAnimator.SetBool("appear", false);

        yield return new WaitForSeconds(1);
        textBox.SetActive(false);
        

    }

    IEnumerator transitionText()
    {
        yield return new WaitForSeconds(2);
        textAnimator.SetBool("appear", false);

        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("textAppear");
        textAnimator.SetBool("appear", true);

    }
    private void startText()
    {
        textBox.SetActive(true);
        FindObjectOfType<AudioManager>().Play("textAppear");
        textAnimator.SetBool("appear", true);
    }
}
