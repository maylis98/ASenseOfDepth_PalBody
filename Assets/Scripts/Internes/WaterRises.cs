using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRises : MonoBehaviour
{
    public Animator waterAnimator;
    public Animator playerAnimator;
    public Animator windAnimator;
    public GameObject fragmentBox1;

    // Start is called before the first frame update
    void Start()
    {
        fragmentBox1.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            waterAnimator.SetBool("waterUp", true);
            playerAnimator.SetBool("scared", true);
            StartCoroutine(boxAppearStopAnim());

        }
    }
    IEnumerator boxAppearStopAnim()
    {
        yield return new WaitForSeconds(3);
        fragmentBox1.SetActive(true);
        windAnimator.SetBool("push", true);

        yield return new WaitForSeconds(1);
        windAnimator.SetBool("push", false);

        yield return new WaitForSeconds(25);
        waterAnimator.SetBool("waterUp", false);
        playerAnimator.SetBool("scared", false);  
        
    }
}
