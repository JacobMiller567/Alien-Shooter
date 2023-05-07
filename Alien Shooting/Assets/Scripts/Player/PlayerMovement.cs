using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    private CharacterController controller;
    private Vector3 velocity;
    private float speed = 6.5f;
    private float gravity = -9.81f;  // default gravity
  //  private float groundDistance = 0.1f; // .4
    private float jumpHeight = 3f;
    private float sprint = 10f;
    private float holdSpeed = 7.5f;

    private bool isRunning;
    private bool onGround;
    //private bool hasStamina = true;


     void Start()
    {
      //  body = GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
        //body.AddForce(0,0,jumpHeight, ForceMode.Impulse);
    }
// Reference: https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
    void Update()
    {
       //onGround = Physics.CheckSphere(groundCheck.position, groundDistance, ground);
       onGround = controller.isGrounded;
       if (onGround && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
      //  Vector3 move = new Vector3(horizontal, 0, vertical);

        controller.Move(move * speed * Time.deltaTime);




        if (Input.GetKey(KeyCode.LeftShift)) // While player holds shift player can sprint
        {
            if(!isRunning) // if player is not already running
            {
              // StartCoroutine(Stamina());
                speed = sprint; // set speed to sprint value
                isRunning = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) // When player releases shift
        {
            speed = holdSpeed; // set speed back to normal
            isRunning = false;
            // StartCoroutine(Stamina());
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            //Debug.Log("Trying to jump!");
            velocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity); // * -
          //  velocity.y += jumpHeight;
          //  body.AddForce(transform.up * jumpHeight);
            //body.velocity = new Vector3 (body.velocity.x,jumpHeight,body.velocity.z);
          //  controller.Move(body.velocity * Time.deltaTime);
            //onGround = false;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

/*

    IEnumerator Stamina() // Used for gun
     {
       hasStamina = false;

       //enemy.GetComponent<PlayerVitals>().PlayerDamaged(gunDamage); // Damage player

       yield return new WaitForSeconds(5f); // Wait one second to fire

       hasStamina = true;
     }

     */
}
