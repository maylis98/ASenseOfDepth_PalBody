using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingUnderwater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fog = false;
        RenderSettings.fogColor = Color.blue;
        RenderSettings.fogDensity = 0.15f;
    }

    bool IsUnderWater()
    {
        return gameObject.transform.position.y >= 5.57f;
    }


    // Update is called once per frame
    void Update()
    {
        RenderSettings.fog = IsUnderWater();
    }
}
