using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetsAngry : MonoBehaviour
{

    public Animator PlayerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAnimator.SetBool("angry", true);
            StartCoroutine(stopAnim());

        }
    }

    IEnumerator stopAnim()
    {
        yield return new WaitForSeconds(1);
        PlayerAnimator.SetBool("angry", false);
    }
}
