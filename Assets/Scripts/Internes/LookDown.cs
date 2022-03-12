using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookDown : MonoBehaviour
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
            PlayerAnimator.SetBool("lookdown", true);
            StartCoroutine(stopAnim());

        }
    }

    IEnumerator stopAnim()
    {
        yield return new WaitForSeconds(6);
        PlayerAnimator.SetBool("lookdown", false);
    }
}
