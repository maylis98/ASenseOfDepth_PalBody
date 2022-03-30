using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRises : MonoBehaviour
{
    public Animator waterAnimator;
    public Animator playerAnimator;
    public Animator windAnimator;
    public GameObject fragmentBox1;

    private BoxCollider boxCollider;

    public float timeUntilGoDown = 20;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = this.GetComponent<BoxCollider>();
        fragmentBox1.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            waterAnimator.SetBool("waterUp", true);
            playerAnimator.SetBool("scared", true);
            boxCollider.enabled = false;
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
        playerAnimator.SetBool("scared", false);

        yield return new WaitForSeconds(timeUntilGoDown);
        waterAnimator.SetBool("waterUp", false);
        
    }
}
