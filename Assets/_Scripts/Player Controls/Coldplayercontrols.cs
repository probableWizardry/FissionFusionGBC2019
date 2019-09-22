using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coldplayercontrols : MonoBehaviour
{

    public float speed = 80f;
    public float jumpHeight = 100f;
    public Rigidbody rb;
    public bool isGrounded;
    private int velocityDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(transform.right * -speed);
        }

        //JUMP CODE DOWN HERE IT'S JANK SO IF YOU KNOW BETTER THEN PLZ FIX. THANK
        if (velocityDelay >= 1)
        {
            if (isGrounded == false)
            {
                rb.AddForce(transform.up * jumpHeight);
            }
        }

        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(transform.up * jumpHeight);
            }

            velocityDelay = 6;
        }

        if (isGrounded == false)
        {
            velocityDelay--;
            rb.AddForce(transform.up * -150);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Terrain")
        {
            isGrounded = false;
        }
    }
    //JUMP CODE ENDS HERE SORRY FOR CODE BLOCK
}
