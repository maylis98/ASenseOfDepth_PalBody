using UnityEngine;

public class ChangeCameraSide : MonoBehaviour
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
        //change this
        CineCameraAnimator.Play("view from Side");
    }

}
