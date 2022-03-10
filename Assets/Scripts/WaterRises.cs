using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRises : MonoBehaviour
{
    public Animator waterAnimator;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            waterAnimator.SetBool("waterUp", true);
            playerAnimator.SetBool("scared", true);
            StartCoroutine(stopAnim());

        }
    }

    IEnumerator stopAnim()
    {
        yield return new WaitForSeconds(10);
        waterAnimator.SetBool("waterUp", false);
        playerAnimator.SetBool("scared", false);
    }
}
