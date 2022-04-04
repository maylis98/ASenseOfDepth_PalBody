using UnityEngine;

public class ChangeCameraSlide : MonoBehaviour
{
    public Animator CineCameraAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchState();
        }
    }

    private void SwitchState()
    {
        CineCameraAnimator.Play("view from Slide");
    }
}
