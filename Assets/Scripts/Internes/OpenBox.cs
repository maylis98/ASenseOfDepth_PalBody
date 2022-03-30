using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox: MonoBehaviour
{
    [SerializeField]
    private Animator boxAnimator;

    [SerializeField]
    private Transform sphereFragment;

    [SerializeField]
    private Animator playerAnimator;

    public float offset;
    public float smoothSpeed = 0.125f;
    bool boxIsTouched;

    // Start is called before the first frame update
    void Start()
    {
        boxIsTouched = false;
        boxAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAnimator.SetBool("touching", true);
            boxIsTouched = true;

            Invoke("touchOnce", 1);

            //Invoke("boxFade", 4);

        }
    }

    private void Update()
    {
        if (boxIsTouched)
        {
            boxFade();
            Invoke("stopAnim", 14);
        }
    }

    private void touchOnce()
    {
        playerAnimator.SetBool("touching", false);
    }
    private void boxFade()
    {
        boxAnimator.SetBool("disappear", true);
        Invoke("sphereUp", 2);
    }

    private void stopAnim()
    {
        boxIsTouched = false;
        boxAnimator.SetBool("disappear", false);
    }

    private void sphereUp()
    {
        float sphereUp = transform.position.y + offset;
        Vector3 desiredPosition = new Vector3(transform.position.x, sphereUp, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(sphereFragment.position, desiredPosition, smoothSpeed);
        sphereFragment.position = smoothedPosition;
    }
}
