using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class FloatObjectWater : MonoBehaviour
{
    public Transform waterLevel;
    public float airDrag = 7.8f;
    public float floatingPower = 40;
    public float smoothSpeed = 0.125f;

    Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        m_Rigidbody.drag = airDrag;
        float waterHeight = waterLevel.position.y;
        float difference = transform.position.y - waterHeight;

        Vector3 desiredPosition = new Vector3(transform.position.x, waterHeight, transform.position.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        m_Rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), transform.position, ForceMode.Force);

        transform.position = smoothedPosition;

    }


}
