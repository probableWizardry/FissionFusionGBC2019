using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotplayercontrols : MonoBehaviour
{

    public float speed = 150f;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
    }
}
