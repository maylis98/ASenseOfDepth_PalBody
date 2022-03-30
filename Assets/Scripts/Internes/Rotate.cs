using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public float degreesPerSecond = 4.0f;

    void Update()
    {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);

    }
}