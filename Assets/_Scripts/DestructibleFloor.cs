using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleFloor : MonoBehaviour
{
    private bool touching = false;
    public int timerMax = 60;
    private int timer;

    private void Start()
    {
        timer = timerMax;
    }

    private void Update()
    {
        if(touching == true)
        {
            timer--;
        }

        if(timer== 0)
        {
            Destroy(gameObject);
        }
    }




    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Hotplayer")
        {
            touching = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Hotplayer")
        {
            touching = false;
            timer = timerMax;
        }
    }

}
