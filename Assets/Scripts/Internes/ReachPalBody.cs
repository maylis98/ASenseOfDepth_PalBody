using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReachPalBody : MonoBehaviour
{
    public Material mArm;
    public Color initialC;
    public Color targetC;
    public float durationAnim;

    public Vector3 initialScale;
    public Vector3 targetScale;
    public Vector3 lastScale;

    public Transform targetPos;
    public GameObject character;
    public GameObject lightOrb;

    public UnityEvent afterArm;

    private bool objAppear = false;

    private void Awake()
    {
        mArm.color = initialC;
        this.gameObject.SetActive(false);
        transform.localScale = initialScale;
        lightOrb.SetActive(false);
    }

    private void Update()
    {
        
        if(objAppear == true)
        {
            transform.Rotate(new Vector3(0f, Time.deltaTime * 40, 0f), Space.World);

            transform.position = Vector3.Lerp(transform.position, targetPos.position, 1 * Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 1 * Time.deltaTime);
            mArm.color = Color.Lerp(mArm.color, targetC, 1 * Time.deltaTime);

            if (transform.localScale.x < 110)
            {
                transform.position = Vector3.Lerp(transform.position, character.transform.position, 1 * Time.deltaTime);
                transform.localScale = Vector3.Lerp(transform.localScale,lastScale, 2 * Time.deltaTime);
                mArm.color = Color.Lerp(mArm.color, initialC, 1f * Time.deltaTime);

                if (transform.localScale.x < 5)
                {
                    objAppear = false;
                    afterArm.Invoke();
                }
            }
        }
        
    }
    public void ObjAppear()
    {
        objAppear = true;
        transform.position = Camera.main.transform.position;
        this.gameObject.SetActive(true);
    }

    public void resetState()
    {
        StartCoroutine(resetParticules());
    }

    IEnumerator resetParticules()
    {
        lightOrb.SetActive(true);

        yield return new WaitForSeconds(7);

        lightOrb.SetActive(false);
    }
}
