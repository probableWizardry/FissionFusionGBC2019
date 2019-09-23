using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Rigidbody targetWallRB;
    private bool pressed = false;

    void Start()
    {
        targetWallRB.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (pressed == false)
        {
            if (other.gameObject.tag == "Coldplayer")
            { 
                gameObject.transform.Translate(0, -0.1f, 0);

                targetWallRB.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

                pressed = true;
            }
        }
    }
}
