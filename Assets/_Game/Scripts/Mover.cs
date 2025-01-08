using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mover : MonoBehaviour
{
    public float jumpPower = 5.0f;
    public float speed = 5.0f;
    public Transform velocityVisual;
    public Transform lookCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.velocity = new Vector3(rb.velocity.x, jumpPower, rb.velocity.z);//Vector3.up;
            rb.velocity = transform.up * jumpPower;

        }
        Vector3 forwardCorrected = lookCamera.forward;
        forwardCorrected.y = 0;
        forwardCorrected.Normalize();
        if (Input.GetKey(KeyCode.A))
        {
            //rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
            rb.velocity = lookCamera.right * -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
            rb.velocity = lookCamera.right * speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
            rb.velocity = forwardCorrected * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
            rb.velocity = forwardCorrected * -speed;
        }
        velocityVisual.localScale = new Vector3(1, 1, rb.velocity.magnitude);
        if(rb.velocity != Vector3.zero)
        {
            velocityVisual.rotation = Quaternion.LookRotation(rb.velocity.normalized);
        }   
    }
}
