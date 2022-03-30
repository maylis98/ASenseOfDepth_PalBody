using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Animator PlayerAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAnimator.SetBool("feetInWater", true);

        }
    }

}
