using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinHenriette : MonoBehaviour
{
    float rotationsPerMinute = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 6.0f * rotationsPerMinute * Time.deltaTime, 0);
    }

    private void OnMouseDown()
    {
        //make henriette jump if clicked
        //if (Input.GetMouseButton(0))
        //{
            //make her jump!

        //}
    }
}
