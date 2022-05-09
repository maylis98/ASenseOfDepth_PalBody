using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; private set; }
    public float startingIntensity;
    public float duration; 

    private CinemachineVirtualCamera cineCamera;
    private CinemachineBasicMultiChannelPerlin cinePerlin;
    private float shakeTimer;

    private void Awake()
    {
        Instance = this;
        cineCamera = GetComponent<CinemachineVirtualCamera>();
        cinePerlin = cineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinePerlin.m_AmplitudeGain = 0f;
    }

    public void ShakeCamera()
    {
        cinePerlin.m_AmplitudeGain = startingIntensity;
        StartCoroutine(stopShaking(startingIntensity, duration));
    }

    IEnumerator stopShaking(float i, float d)
    {
        float time = 0;
        cinePerlin.m_AmplitudeGain = i;
        while (time < d)
        {
            cinePerlin.m_AmplitudeGain = Mathf.Lerp(cinePerlin.m_AmplitudeGain, 0f, time / d);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
