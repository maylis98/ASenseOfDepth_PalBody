using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgAppear : MonoBehaviour
{
    [SerializeField] private GameObject ObjFragment;
    public Animator ImageAnimator;

    private void Start()
    {
        ObjFragment.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ObjFragment.SetActive(true);
            ImageAnimator = ObjFragment.GetComponent<Animator>();
            ImageAnimator.SetBool("appearing", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            ImageAnimator.SetBool("appearing", false);
            /*ObjFragment.SetActive(false);*/
        }
    }
}
