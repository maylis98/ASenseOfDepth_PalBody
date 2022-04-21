using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCanvasManager : MonoBehaviour
{
    public GameObject imageFrame;
    private Animator imageAnimator;
    private AudioSource audioImage;
    public Sprite[] images;
    public int closeAfter;

    private void Start()
    {
        imageFrame.SetActive(false);
        imageAnimator = imageFrame.GetComponent<Animator>();
        audioImage = GetComponent<AudioSource>();
    }

    public void changeImage(int imageIndex)
    {
        imageFrame.SetActive(true);
        imageFrame.GetComponent<Image>().sprite = images[imageIndex];
        imageAnimator.SetBool("hideContent", false);
        audioImage.Play();
        
        StartCoroutine(closeAfterSeconds(closeAfter));
    }

    IEnumerator closeAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        
        imageAnimator.SetBool("hideContent", true);
        audioImage.Stop();

    }
}
