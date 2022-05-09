using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public bool IsHolding;
    private Rigidbody rBody;
    private MeshRenderer mRenderer;

    private void Awake()
    {
        mRenderer = GetComponent<MeshRenderer>();
        rBody = GetComponent<Rigidbody>();
        mRenderer.enabled = false;
        rBody.isKinematic = true;
    }

    public void FallingObj()
    {
        mRenderer.enabled = true;
        rBody.isKinematic = IsHolding;
        CameraShake.Instance.ShakeCamera();
    }
}
