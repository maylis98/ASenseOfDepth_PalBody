using System.Collections;
using UnityEngine;

public class ThirdPersonMovement2D : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;

    public float speed = 6;
    public float jumpForce = 10;
    public float gravityScale = 0;
    public Transform groundCheck;
    public LayerMask groundLayer; 

    public Animator animator;

    public Transform model;

    public GameObject followingObj;

    private void Start()
    {
        followingObj.SetActive(false);
    }

    void Update()
    {
       //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        direction.x = horizontal * speed;

        bool IsGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        animator.SetBool("isGrounded", IsGrounded);

        if (IsGrounded) { 
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
            
            }
        }

        if (horizontal != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(horizontal, 0, 0));
            model.rotation = newRotation;
        }

        animator.SetFloat("speed", Mathf.Abs(horizontal));
     

        direction.y += (Physics.gravity.y * gravityScale); /** Time.deltaTime;*/
        controller.Move(direction * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChangeCamera"))
        {
            StartCoroutine(FieldAppear());
        }
    }

    IEnumerator FieldAppear()
    {
        yield return new WaitForSeconds(4);
        followingObj.SetActive(true);

        yield return new WaitForSeconds(6);
        FindObjectOfType<ScaleLerper>().ChangeScale();
    }

    /*private void OnTriggerEnter(Collider other)
    {
        direction.x = 0;
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        yield return new WaitForSeconds(2);
        direction.x = horizontal * speed;
    }*/
}