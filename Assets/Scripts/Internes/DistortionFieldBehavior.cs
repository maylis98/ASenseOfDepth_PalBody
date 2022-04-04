using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortionFieldBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChangeCamera"))
        {
            this.gameObject.SetActive(true);
        }
    }
}