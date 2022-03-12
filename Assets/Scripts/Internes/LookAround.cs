using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
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
            PlayerAnimator.SetBool("lookaround", true);
            StartCoroutine(stopAnim());

        }
    }

    IEnumerator stopAnim()
    {
        yield return new WaitForSeconds(1);
        PlayerAnimator.SetBool("lookaround", false);
    }
}
