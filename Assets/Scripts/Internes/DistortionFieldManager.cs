using System.Collections;
using UnityEngine;

public class DistortionFieldManager : MonoBehaviour
{
    public Transform target;

    public Vector3 smallSize;
    public Vector3 bigSize;
    public float transitionTime;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        this.gameObject.transform.localScale = smallSize;
    }

    public void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
     
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

    }

    public void ChangeOffset()
    {
        offset = new Vector3(7, 0, 0);

        FixedUpdate();
    }

    public void goBig()
    {
        StartCoroutine(LerpFunction(bigSize, transitionTime));
    }

    public void goSmall()
    {
        StartCoroutine(LerpFunction(smallSize, transitionTime));
    }

    IEnumerator LerpFunction(Vector3 endValue, float duration)
    {
        float time = 0;
        Vector3 startingScale = this.gameObject.transform.localScale;
        while (time < duration)
        {
            this.gameObject.transform.localScale = Vector3.Lerp(startingScale, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
            this.gameObject.transform.localScale = endValue;
        }

    }

    IEnumerator enableAfter(float duration)
    {
        yield return new WaitForSeconds(duration + 1);
        MeshRenderer fieldMR = GetComponent<MeshRenderer>();
        fieldMR.enabled = false;

    }

    public void fieldDisappear() 
    {
        goSmall();
        StartCoroutine(enableAfter(transitionTime));
        
    }

}
