using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GetsAngry : MonoBehaviour
{
    public Animator CineCameraAnimator;
    public Animator PlayerAnimator;
    public Volume PP;

    private void Start()
    {
        PP.priority = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAnimator.SetBool("angry", true);
            SwitchState();

            StartCoroutine(stopAnim());

        }
    }

    IEnumerator stopAnim()
    {
        yield return new WaitForSeconds(8);
        PlayerAnimator.SetBool("angry", false);
        CineCameraAnimator.Play("view from Side");
        PP.priority = 0;
    }

    private void SwitchState()
    {
        //change this
        CineCameraAnimator.Play("view Focus");
        PP.priority = 2;
    }
}
