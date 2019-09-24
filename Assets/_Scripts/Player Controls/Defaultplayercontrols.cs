using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defaultplayercontrols: MonoBehaviour
{

    public float speed = 100f;
    public float jumpHeight = 100f;
    public float fallSpeed = 150f;
    public Rigidbody rb;
    public bool isGrounded;
    private int velocityDelay;
    public Transform raycastNode;

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


        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            }
        }

        if (isGrounded == false)
        {
            if (rb.velocity.y <= -0.1f)
            {
                rb.AddForce(transform.up * -fallSpeed);
            }
        }

        RaycastHit hit;

        if (Physics.Raycast(raycastNode.position, raycastNode.up, out hit, .02f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
 }
