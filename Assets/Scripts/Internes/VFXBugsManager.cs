using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXBugsManager : MonoBehaviour
{
    public VisualEffect VFXBugs;

    private void Awake()
    {
        VFXBugs.SetInt("Number of Particules", 0);
        
    }

    public void BugsAppear()
    {
        VFXBugs.SetInt("Number of Particules", 727000);
        VFXBugs.SetFloat("Attractive Strength", 7f);
    }

    public void BugsSpread()
    {
        VFXBugs.SetFloat("Attractive Strength", 1.6f);
    }
    public void BugsAttracted()
    {
        VFXBugs.SetFloat("Attractive Strength", 9f);
    }

    public void BugsDisappear()
    {
        VFXBugs.SetInt("Number of Particules", 0);

        this.gameObject.SetActive(false);
    }



}
