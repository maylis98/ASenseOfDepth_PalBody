using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Events;

public class OpenBox: MonoBehaviour
{
    [SerializeField]
    private UnityEvent trigger;

    //Elements to trigger
    [SerializeField]
    private Animator boxAnimator;

    public GameObject box;

    [SerializeField]
    private Transform sphereFragment;

    [SerializeField]
    private Animator playerAnimator;

    public float offset;
    public float smoothSpeed = 0.125f;
    bool boxIsTouched;

    //VFX
    [SerializeField]
    private VisualEffect visualEffect;

    //VFX properties
    [SerializeField, Range(0, 6)]
    private float expansion = 0;

    [SerializeField, Range(0, 7)]
    private float spread = 0;

    [SerializeField, Range(0, 4)]
    private float fluxIntensity = 0;


    // Start is called before the first frame update
    void Start()
    {
        boxIsTouched = false;
        boxAnimator = GetComponent<Animator>();

        DisactiveBox();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAnimator.SetBool("touching", true);
            boxIsTouched = true;

            Invoke("touchOnce", 1);

            //Invoke("boxFade", 4);

        }
    }

    private void Update()
    {
        if (boxIsTouched)
        {
            boxFade();
            Invoke("stopAnim", 14);
        }
    }

    private void touchOnce()
    {
        playerAnimator.SetBool("touching", false);
    }
    private void boxFade()
    {
        boxAnimator.SetBool("disappear", true);
        Invoke("sphereUp", 2);
    }

    private void stopAnim()
    {
        boxIsTouched = false;
        boxAnimator.SetBool("disappear", false);
    }

    private void sphereUp()
    {
        float sphereUp = transform.position.y + offset;
        Vector3 desiredPosition = new Vector3(transform.position.x, sphereUp, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(sphereFragment.position, desiredPosition, smoothSpeed);
        sphereFragment.position = smoothedPosition;

        visualEffect.SetFloat("Lifetime Expansion", expansion);
        visualEffect.SetFloat("Spread", spread);
        visualEffect.SetFloat("Flux Intensity", fluxIntensity);

        StartCoroutine(sphereExpand());
    }

    IEnumerator sphereExpand()
    {
        yield return new WaitForSeconds(3);

        //Change VFX values
        visualEffect.SetFloat("Lifetime Expansion", 3.1f);
        visualEffect.SetFloat("Spread", spread);
        visualEffect.SetFloat("Flux Intensity", 3.1f);

        yield return new WaitForSeconds(3);

        trigger.Invoke();
    }

    private void endFragment()
    {
        //canvasAnimator.SetBool("IsFinished", true);
    }

    public void endVFX()
    {
        //Change VFX values
        visualEffect.SetFloat("Lifetime Expansion", 0f);
        visualEffect.SetFloat("Spread", 0f);
        
    }

    IEnumerator deleteSphere()
    {
        yield return new WaitForSeconds(3);

        visualEffect.enabled = false;
    }

    public void ActiveBox()
    {
        box.SetActive(false);
    }

    public void DisactiveBox()
    {

        box.SetActive(false);

    }



}
