using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldManager : MonoBehaviour
{
    public Vector3 smallSize;
    public Vector3 bigSize;
    public float transitionTime;
    private MeshRenderer forceFieldRenderer;

    void Start()
    {
        this.gameObject.transform.localScale = smallSize;
        forceFieldRenderer = GetComponent<MeshRenderer>();
        forceFieldRenderer.enabled = false;
    }
    
    public void PalRecoversField()
    {
        StartCoroutine(PalRecovers(transitionTime));
    }
    private void fieldExpand()
    {
        StartCoroutine(LerpFunction(bigSize, transitionTime));
    }
    private void fieldReduce()
    {
        StartCoroutine(LerpFunction(smallSize, transitionTime));
    }

    IEnumerator PalRecovers(float waitingTime)
    {
        forceFieldRenderer.enabled = true;
        fieldExpand();

        yield return new WaitForSeconds(waitingTime);
        fieldReduce();

        yield return new WaitForSeconds(waitingTime);
        forceFieldRenderer.enabled = true;
        StopAllCoroutines();
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

}
