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

        //THIS IS THE PROBLEM
        Vector3 move = new Vector3(Input.GetAxis("Vertical") * -1, 0, Input.GetAxis("Horizontal"));
        //maybe check if velocity on the vertical axis is negative, then invert controls if so? maybe check rotation. let camera keep moving after player stops moving

        controller.Move(move * Time.deltaTime * playerSpeed);
        //THESE LINES RIGHT HERE

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            playerAnim.SetTrigger("Run");          
        } else if (move == Vector3.zero)
        {
            playerAnim.SetBool("Run", false);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime); //THIS LINE MAY ALSO BE A PROBLEM?
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chick"))
        {
            Destroy(collision.gameObject);
            captured += 1;
            GameManager.runningTotal += 1;
            //add cheep cheep
            source.PlayOneShot(cheep);
        }

        if (collision.gameObject.CompareTag("speedUp"))
        {
            Debug.Log("Speed up!");
            Destroy(collision.gameObject);
            playerAnim.Play("Eat");
            playerAnim.Play("Eat");
            playerAnim.SetTrigger("Run");
            playerSpeed += 2.0f;           
        }
    }
}


