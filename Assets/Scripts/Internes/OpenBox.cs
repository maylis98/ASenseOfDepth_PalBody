using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Events;

public class OpenBox: MonoBehaviour
{

    [SerializeField]
    private UnityEvent boxTouched;

    [SerializeField]
    private UnityEvent sphereIsUp;
    

    //Elements to trigger
    public GameObject box;
    public GameObject rippleSphere;

    private Transform sphereFragment;
    private VisualEffect visualEffect;

    [SerializeField]
    private Animator playerAnimator;

    public float offset;
    public float smoothSpeed = 0.125f;
    bool boxIsTouched;


    //VFX properties
    [SerializeField, Range(0, 6)]
    private float expansion = 0;

    [SerializeField, Range(0, 7)]
    private float spread = 0;

    [SerializeField, Range(0, 4)]
    private float fluxIntensity = 0;


    void Start()
    {
        boxIsTouched = false;
        sphereFragment = rippleSphere.GetComponent<Transform>();
        visualEffect = rippleSphere.GetComponent<VisualEffect>();

        DisactiveBox();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            boxIsTouched = true;
            boxTouched.Invoke();

        }
    }

    private void Update()
    {
        if (boxIsTouched)
        {
            Invoke("sphereUp", 2);
        }
    }

    private void stopAnim()
    {
        boxIsTouched = false;
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

        sphereIsUp.Invoke();
        StopAllCoroutines();
    }

    public void endFragment()
    {
            visualEffect.SetFloat("Lifetime Expansion", 0f);
            visualEffect.SetFloat("Spread", 0f);
            visualEffect.SetFloat("Number of Particles", 0f);

            //Invoke("DisactiveBox", 5);
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
