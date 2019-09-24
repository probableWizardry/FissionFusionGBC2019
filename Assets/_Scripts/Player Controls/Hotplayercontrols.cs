using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotplayercontrols : MonoBehaviour
{

    public float speed = 150f;
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

    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            rb.AddForce(transform.right * speed);
        }
        if (Input.GetKey(KeyCode.J))
        {
            rb.AddForce(transform.right * -speed);
        }

        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.I))
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
