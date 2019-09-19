﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defaultplayercontrols: MonoBehaviour
{

    public float speed = 100f;
    public Rigidbody rb;

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
    }
}