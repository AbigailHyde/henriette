using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool grounded;
    private float playerSpeed = 4.0f;
    private float gravity = -9.81f;
    private Animator playerAnim;
    public static float cooldown;
    public static int captured;
    public AudioClip cheep;
    public AudioSource source;

    // Camera follow parameters
    public Transform playerCamera; // Reference to the player's camera
    public float cameraDistance = 5.0f; // Camera's distance from the player
    public float cameraHeight = 2.0f; // Camera's height above the player
    public float rotationSpeed = 5.0f; // Rotation speed for smooth turning
    public float followSpeed = 10.0f; // Follow speed for smooth movement

    private Vector3 currentVelocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        controller = gameObject.GetComponent<CharacterController>();
        playerAnim = GetComponent<Animator>();
        captured = 0;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = controller.isGrounded;
        if (grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Get input for movement
        float moveDirection = Input.GetAxis("Vertical");
        float strafeDirection = Input.GetAxis("Horizontal");

        // Get camera's forward and right direction
        Camera mainCamera = Camera.main;
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        // Make sure the movement is aligned with the camera (ignoring vertical camera tilt)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Calculate the move direction based on the camera orientation
        Vector3 move = forward * moveDirection + right * strafeDirection;

        // Move the player character
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Update player animations based on movement
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move; // Ensure the player faces the direction of movement
            playerAnim.SetTrigger("Run");          
        }
        else if (move == Vector3.zero)
        {
            playerAnim.SetBool("Run", false);
        }

        // Apply gravity
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime); 

        // Camera follow logic (without using mouse)
        FollowCamera(move);
    }

    // Function to handle the camera following and smooth rotation (No mouse input)
    private void FollowCamera(Vector3 move)
    {
        // Camera position (behind the player with an offset)
        Vector3 targetPosition = transform.position - transform.forward * cameraDistance + Vector3.up * cameraHeight;
        playerCamera.position = Vector3.SmoothDamp(playerCamera.position, targetPosition, ref currentVelocity, followSpeed * Time.deltaTime);

        // Rotate the camera smoothly to follow the direction the player is moving
        if (move != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move); // Camera faces the movement direction
            playerCamera.rotation = Quaternion.Slerp(playerCamera.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // Handle collision events
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chick"))
        {
            Destroy(collision.gameObject);
            captured += 1;
            GameManager.runningTotal += 1;
            // Play sound when a chick is captured
            source.PlayOneShot(cheep);
        }

        if (collision.gameObject.CompareTag("speedUp"))
        {
            Destroy(collision.gameObject);
            playerAnim.Play("Eat");
            playerAnim.SetTrigger("Run");
            playerSpeed += 2.0f; // Increase speed
        }
    }
}
