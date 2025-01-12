using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    //public Transform target;
    //public Transform camTransform;
    //public float smoothSpeed = 0.125f;
    //public Vector3 offset;

    //public float mouseSensitivity = 100f;

    //private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        //offset = camTransform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //rotation


        //lerp
        //Vector3 desiredPosition = target.position + offset;
        //camTransform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        //transform.LookAt(target);
    }



}
