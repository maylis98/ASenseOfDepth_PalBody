// Floater v0.0.2
// by Donovan Keith
// [MIT License]

using UnityEngine;
using System.Collections;
using UnityEngine.Events;

// Makes objects float up & down while gently spinning.
public class FloatObject : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 4.0f;
    public float frequency = 0.1f;
    public float duration;
    public Material mArm;
    public Color initialC;
    public Color targetC;

    public UnityEvent afterArm;

    // Position Storage Variables
    private Vector3 posOffset = new Vector3();
    private Vector3 tempPos = new Vector3();
    private float amplitude;
    private bool objectAppear;

    // Use this for initialization
    void Awake()
    {
        mArm.color = initialC;
        amplitude = 0.02f;
        objectAppear = false;
        this.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (objectAppear == true)
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

    public void ObjAppear()
    {
        objectAppear = true;
        this.gameObject.SetActive(true);
        StartCoroutine(armTimeline());
    }

    IEnumerator armTimeline()
    {
        StartCoroutine(LerpMColor(targetC));

        yield return new WaitForSeconds(duration);

        StartCoroutine(LerpMColor(initialC));

        yield return new WaitForSeconds(duration);

        objectAppear = false;
        afterArm.Invoke();
    }

    /*IEnumerator LerpAmplitude(float endValue)
    {
        float time = 0;
        while (time < duration)
        {
            amplitude = Mathf.Lerp(amplitude, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
            
        }
        amplitude = endValue;
    }*/

    IEnumerator LerpMColor(Color targetColor)
    {
        float time = 0;
        Color startColor = mArm.color;
        while (time < duration)
        {
            mArm.color = Color.Lerp(startColor, targetColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        mArm.color = targetColor;
    }
}