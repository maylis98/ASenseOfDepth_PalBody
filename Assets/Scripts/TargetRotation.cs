using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour
{
    public Vector3 RotateAmount;
    void Start()
    {
        
    }

    

    void Update()
    {
        transform.Rotate(RotateAmount * Time.deltaTime);
    }
}
