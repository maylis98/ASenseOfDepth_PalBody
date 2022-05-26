using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleManager : MonoBehaviour
{
    public GameObject lightRay;
    public Rigidbody rB;

    private Animator capsuleA;

    private void Start()
    {
        capsuleA = GetComponent<Animator>();
        lightRay.SetActive(false);
        rB.detectCollisions = true;
    }

    public void IsTouched()
    {
        capsuleA.SetBool("isTouched", true);
        lightRay.SetActive(true);
        rB.detectCollisions = false;
    }

    public void Leave()
    {
        gameObject.SetActive(false);
        lightRay.SetActive(false);

    }
}

