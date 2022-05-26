// Floater v0.0.2
// by Donovan Keith
// [MIT License]

using UnityEngine;
using System.Collections;
using UnityEngine.Events;

// Makes objects float up & down while gently spinning.
public class Levitating : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 4.0f;
    public float frequency = 0.1f;
    public float amplitude;


    // Position Storage Variables
    private Vector3 posOffset = new Vector3();
    private Vector3 tempPos = new Vector3();

    // Update is called once per frame
    void Update()
    {

        // Store the starting position & rotation of the object
        posOffset = transform.position;

        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }

}