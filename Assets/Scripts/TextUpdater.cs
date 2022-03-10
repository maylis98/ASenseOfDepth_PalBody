using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    public GameObject textBox;

    void Start()
    {
        textBox.SetActive(true);
        textMesh = textBox.GetComponent<TextMeshProUGUI>();
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
            StartCoroutine(lookAround2());

        }

        if (other.CompareTag("Front Stairs"))
        {
            StartCoroutine(frontStairs());

        }

        if (other.CompareTag("Cant Jump"))
        {
            StartCoroutine(cantJump());

        }

        if (other.CompareTag("LosyPlace"))
        {
            StartCoroutine(losyPlace());

        }

        if (other.CompareTag("WaterRises"))
        {
            StartCoroutine(waterRises());

        }
    }

    IEnumerator lookAround()
    {
        yield return new WaitForSeconds(1);

        textBox.SetActive(true);
        textMesh.text = "What is this place ?";
        StartCoroutine(delete());

    }

    IEnumerator lookDown()
    {
        yield return new WaitForSeconds(1);

        textBox.SetActive(true);
        textMesh.text = "...strange feets...";

        yield return new WaitForSeconds(3);

        textMesh.text = "...as if I was anchored to the ground...";

        StartCoroutine(delete());


    }

    IEnumerator walkFewSteps()
    {
        yield return new WaitForSeconds(3);

        textBox.SetActive(true);
        textMesh.text = "...at least I'm not stuck in it...";

        yield return new WaitForSeconds(3);

        textMesh.text = "There's probably a way out...";

        yield return new WaitForSeconds(2);

        textMesh.text = "...I hope";

        StartCoroutine(delete());

    }

    IEnumerator lookAround2()
    {
        yield return new WaitForSeconds(1);

        textBox.SetActive(true);
        textMesh.text = "Let's keep walking ... while we can";

        yield return new WaitForSeconds(3);

        textMesh.text = "This place is truly desterted...";

        yield return new WaitForSeconds(3);

        textMesh.text = "...I wonder what happened";

        yield return new WaitForSeconds(3);

        textMesh.text = "...I mean...";

        yield return new WaitForSeconds(1);

        textMesh.text = "Why am I here in the first place ? ...";

        StartCoroutine(delete());

    }

    IEnumerator frontStairs()
    {
        yield return new WaitForSeconds(1);

        textBox.SetActive(true);
        textMesh.text = "Ah... typical platform for jump";

        yield return new WaitForSeconds(3);

        textMesh.text = "...to avoid...";

        yield return new WaitForSeconds(2);

        textMesh.text = "...water...";

        StartCoroutine(delete());

    }

    IEnumerator cantJump()
    {
        yield return new WaitForSeconds(1);

        textBox.SetActive(true);
        textMesh.text = "Wait...what ?";

        yield return new WaitForSeconds(3);

        textMesh.text = "I can't jump properly !";

        yield return new WaitForSeconds(2);

        textMesh.text = "I can't avoid water !";

        yield return new WaitForSeconds(4);

        textMesh.text = "Ok well... let's try those stairs...";

        StartCoroutine(delete());

    }

    IEnumerator losyPlace()
    {
        yield return new WaitForSeconds(1);

        textBox.SetActive(true);
        textMesh.text = "Who put me in this lame place ?!";

        yield return new WaitForSeconds(3);

        textMesh.text = "...with...";

        yield return new WaitForSeconds(2);

        textMesh.text = "...water...";

        yield return new WaitForSeconds(5);

        textMesh.text = "...I really don't like it...";


        StartCoroutine(delete());

    }

    IEnumerator waterRises()
    {
        yield return new WaitForSeconds(2);
        textBox.SetActive(true);
        textMesh.text = "Oh no...";

        yield return new WaitForSeconds(2);

        textMesh.text = "What is happening ?";

        yield return new WaitForSeconds(4);

        textMesh.text = "...I'm gonna drown !";

        yield return new WaitForSeconds(2);

        textMesh.text = "...I can't run !";

        yield return new WaitForSeconds(2);

        textMesh.text = "...I can't jump !";


        StartCoroutine(delete());

    }

    IEnumerator delete()
    {
        yield return new WaitForSeconds(2);

        textBox.SetActive(false);

    }
}
