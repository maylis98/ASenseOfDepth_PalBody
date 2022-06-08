using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimelineLauncher : MonoBehaviour
{
    public UnityEvent sceneStarted;

    void Start()
    {
        sceneStarted.Invoke();
    }

}
