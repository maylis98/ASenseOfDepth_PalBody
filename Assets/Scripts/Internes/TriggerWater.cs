using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerWater: MonoBehaviour
{
    [SerializeField]
    private UnityEvent touchWater;

    [SerializeField]
    private UnityEvent after1Second;

    [SerializeField]
    private UnityEvent after5Seconds;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerLimit"))
        {
            touchWater.Invoke();
            CameraShake.Instance.ShakeCamera();
            StartCoroutine(stopAnim());
        }
    }

    IEnumerator stopAnim()
    {
        yield return new WaitForSeconds(1);
        after1Second.Invoke();

        yield return new WaitForSeconds(7);
        after5Seconds.Invoke();
    }
}
