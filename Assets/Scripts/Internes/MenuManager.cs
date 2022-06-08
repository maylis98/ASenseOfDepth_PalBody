using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Animator canvasA;


    public void showPalBody() 
    {
        canvasA.SetBool("load", true);
    }
}
