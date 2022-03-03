using System.Collections;
using UnityEngine;

public class ThirdPersonMovement2D : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;

    public float speed = 6;
    public float jumpForce = 10;
    public float gravity = 0;

    public Animator animator;

    public Transform model;
    
    void Update()
    {
       //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        direction.x = horizontal * speed;

        animator.SetFloat("speed", Mathf.Abs(horizontal));

        //walk
        direction.y += gravity * Time.deltaTime; 

        if (Input.GetButtonDown("Jump"))
        {
            direction.y = jumpForce;
        }

       /* if (horizontal != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(horizontal, 0, 0));
            model.rotation = newRotation;
        }*/


        controller.Move(direction * Time.deltaTime);
    }
}