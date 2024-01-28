using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// General purpose Third-Person Movement w/ Jumping using Cinemachine 
// Cinemachine settings will need tweaking depending on Dog Model 
public class ThirdPersonMovement : MonoBehaviour
{
    // Gen purpose for camera and character controller
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cam;

    // Variables used in GroundCheck for gravity and jump resetting
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    // Variables used for movement, speed, and smooth turn velocity
    [SerializeField] float speed = 6f;
    float turnSmoothVelocity;
    [SerializeField] float turnSmoothTime = 0.1f;

    // Gravity and jump height, self explanatory
    // But assuming it isn't, gravity determines how fast you fall and jump height is how high you jump
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float jumpHeight = 3f;

    [SerializeField] AudioClip scrape;

    AudioSource audioSource;
    Vector3 velocity;
    bool isGrounded;

    // Start function locks and hides cursor
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If grounded and velocity is negative, set it to -2f so it doesn't snowball into the negative hundreds/thousands
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Takes input, creates direction vector
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        // If grounded and you're pressing spacebar, then jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        // Constant gravity calculations
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // Gross math for third person camera
        // Takes camera angle, applies a variety of disgusting trigonometries, then the character will move the direction
        // that the camera is facing 
        if(direction.magnitude >= 0.1f)
        {
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(scrape);
            }

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            audioSource.Stop();
        }

        // void FootStep()
        // {
        //     if(!audioSource.isPlaying)
        //     {
        //         audioSource.PlayOneShot(scrape);
        //     }
        // }
    }
}
