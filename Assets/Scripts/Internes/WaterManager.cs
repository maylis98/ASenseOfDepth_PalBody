using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{
    private Animator waterAnimator;

    private void Start()
    {
        waterAnimator = GetComponent<Animator>();
    }

    public void WaterGoUp()
   {
       waterAnimator.SetBool("waterUp", true);
   }

    public void WaterGoDown()
    {
        waterAnimator.SetBool("waterUp", false);
    }


}
