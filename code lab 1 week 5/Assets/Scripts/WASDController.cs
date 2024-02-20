using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDController : MonoBehaviour
{
    Rigidbody rb;
        
    public float forceAmt = 100;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {

            rb.AddForce(Vector3.up * forceAmt);

        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {

            rb.AddForce(Vector3.down * forceAmt);

        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {

            rb.AddForce(Vector3.left * forceAmt);

        }

        if (Input.GetKeyDown(KeyCode.D))
        {

            rb.AddForce(Vector3.right * forceAmt);

        }

    }

}
