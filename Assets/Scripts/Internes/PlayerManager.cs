using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Animator characterAnimator;

   public void IsScared()
    {
        characterAnimator.SetBool("scared", true);
    }

    public void IsNotScared()
    {
        characterAnimator.SetBool("scared", false);
    }

    public void LookAround()
    {
        characterAnimator.SetBool("lookaround", true);
    }

    public void endLookAround()
    {
        characterAnimator.SetBool("lookaround", false);
    }

}
