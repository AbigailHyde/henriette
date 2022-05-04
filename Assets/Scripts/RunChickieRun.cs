using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunChickieRun : MonoBehaviour
{
    private float timeToChangeDirection;
    private Rigidbody chickieRb;
    private Vector3 randomVector;
    private float speed;
    private float jumpOrRun;
    private float countdown;
    private Animator chickAnim;

    // Start is called before the first frame update
    void Start()
    {
        chickieRb = GetComponent<Rigidbody>();
        speed = (PlayerPrefs.GetFloat("Difficulty") + 1) * Random.Range(0.1f, 2);
        jumpOrRun = Random.Range(0.0f, 10.0f);
        chickAnim = GetComponent<Animator>();
        countdown = Random.Range(3.0f, 10.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = gameObject.transform.position + ((speed * Time.deltaTime) * gameObject.transform.forward);
        gameObject.transform.Rotate(0, Random.Range(-15,15), 0,Space.Self);
        if (jumpOrRun > 5.0f)
        {
            if (countdown > 0)
            {
                chickAnim.SetTrigger("Run");
            } else
            {
                jumpOrRun = Random.Range(0.0f, 10.0f);
            }
            
        }
        else if (jumpOrRun <= 5.0f)
        {
            if (countdown > 0)
            {
                chickAnim.SetTrigger("Jump");
            }
            else
            {
                jumpOrRun = Random.Range(0.0f, 10.0f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fence") || collision.gameObject.CompareTag("Rock"))
        {
            gameObject.transform.Rotate(0, 180, 0, Space.Self);
        }
    }
}
