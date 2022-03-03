using System.Collections;
using UnityEngine;

public class RotateAroundTarget : MonoBehaviour
{
    public GameObject target;
    public Vector3 RotationAmount;
    float orbitSpeed = 10;
    
    void Start()
    {
       
        
    }
    void Update()
    {

        transform.RotateAround(target.transform.position, RotationAmount, orbitSpeed * Time.deltaTime); 

    }
}
