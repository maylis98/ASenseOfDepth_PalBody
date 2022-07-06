using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CapsuleManager : MonoBehaviour
{
    public GameObject lightRay;
    public Rigidbody rB;
    public Animator capsuleA;

    public UnityEvent whenIsTouched;
    public UnityEvent afterSeconds;


    private void Start()
    {
        lightRay.SetActive(false);
        rB.detectCollisions = true;
    }

    public void IsTouched()
    {
        capsuleA.SetBool("isTouched", true);
        rB.detectCollisions = false;
        whenIsTouched.Invoke();

        StartCoroutine(WaitForSeconds(1));
    }

    public void Leave()
    {
        gameObject.SetActive(false);

    }

    IEnumerator WaitForSeconds(float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);

        afterSeconds.Invoke();


    }
}

