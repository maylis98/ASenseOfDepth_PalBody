using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
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
            PlayerAnimator.SetBool("stairs", true);
            StartCoroutine(stopAnim());

        }
    }

    IEnumerator stopAnim()
    {
        yield return new WaitForSeconds(3);
        PlayerAnimator.SetBool("stairs", false);
    }
}
