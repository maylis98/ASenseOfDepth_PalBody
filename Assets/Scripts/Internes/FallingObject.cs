using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public GameObject[] fallingObjs;
    public bool IsHolding;
    public AudioSource fallingSound;

    private Rigidbody rBody;
    private MeshRenderer mRenderer;

    private void Awake()
    {
        foreach (GameObject cylinder in fallingObjs)
        {
            mRenderer = cylinder.GetComponent<MeshRenderer>();
            rBody = cylinder.GetComponent<Rigidbody>();
            mRenderer.enabled = false;
            rBody.isKinematic = true;
        }
        
    }

    public void FallingObj()
    {
        foreach (GameObject cylinder in fallingObjs)
        {
            mRenderer = cylinder.GetComponent<MeshRenderer>();
            rBody = cylinder.GetComponent<Rigidbody>();
            mRenderer.enabled = true;
            rBody.isKinematic = IsHolding;
        }
        CameraShake.Instance.ShakeCamera();
        fallingSound.Play();

    }
}
