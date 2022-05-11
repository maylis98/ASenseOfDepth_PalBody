using System.Collections;
using UnityEngine;

public class ThirdPersonMovement2D : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;

    private bool moveRight;
    private bool moveBackwards;

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
        moveBackwards = false;
        //followingObj.SetActive(false);
    }

    void Update()
    {
        EventManager.StartListening("PlayerInput", stateofMove);
        EventManager.StartListening("PlayerBack", moveBack);
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

    private void moveBack(object backButtonIsPressed)
    {
        moveBackwards = (bool)backButtonIsPressed;

        if (moveBackwards == true)
        {
            horizontal = -1;
            FindObjectOfType<DistortionFieldManager>().goSmall();
        }
        else
        {
            return;
        }
    }

    private void keyboardInput()
    {
        //WALK
        //float horizontal = Input.GetAxisRaw("Horizontal");
        direction.x = horizontal * speed;

        bool IsGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        animator.SetBool("isGrounded", IsGrounded);

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

}