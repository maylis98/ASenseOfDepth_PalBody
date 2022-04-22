using System.Collections;
using UnityEngine;

public class ThirdPersonMovement2D : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;

    private bool moveRight;
    private float horizontal;
    public float speed;
    public float jumpForce = 10;
    public float gravityScale = 0;
    public Transform groundCheck;
    public LayerMask groundLayer; 

    public Animator animator;

    public Transform model;

    public GameObject followingObj;

    private void Start()
    {
        moveRight = false;
        //followingObj.SetActive(false);
    }

    void Update()
    {
        EventManager.StartListening("PlayerInput", stateofMove);
        keyboardInput();

    }

    private void stateofMove(object buttonIsPressed)
    {
        moveRight = (bool)buttonIsPressed;

        if (moveRight == true)
        {
            horizontal = 1;
            FindObjectOfType<DistortionFieldManager>().goSmall();
            //followingObj.SetActive(false);
            //FindObjectOfType<NativeWebsocketChat>().SendChatMessage("distortion field");
            
        }
        else if (moveRight == false)
        {
            horizontal = 0;
            FindObjectOfType<DistortionFieldManager>().goBig();
            //StartCoroutine(FieldAppear());
        }
    }

    private void keyboardInput()
    {
        //WALK
        //float horizontal = Input.GetAxisRaw("Horizontal");
        direction.x = horizontal * speed;

        bool IsGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        animator.SetBool("isGrounded", IsGrounded);

        if (IsGrounded)
        {
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

        Vector3 currentMovement = new Vector3(direction.x, direction.y, direction.z);
        controller.Move(currentMovement * Time.deltaTime);
    }

   /* IEnumerator FieldAppear()
    {
        yield return new WaitForSeconds(4);
        FindObjectOfType<DistortionFieldManager>().goSmall();

        yield return new WaitForSeconds(6);
        FindObjectOfType<ScaleLerper>().ChangeScale();
    }*/

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