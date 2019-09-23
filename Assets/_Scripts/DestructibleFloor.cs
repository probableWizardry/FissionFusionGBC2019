using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleFloor : MonoBehaviour
{
    private bool touching = false;
    public int timerMax = 60;
    private int timer;
    private Renderer objectRenderer;
    private Color terrainColor;

    private void Start()
    {
        terrainColor = new Color(0.245f, 0.181f, 0.101f);
        objectRenderer = gameObject.GetComponent<Renderer>();
        timer = timerMax;
    }

    private void Update()
    {
        

        if(touching == true)
        {
            timer--;
        }

        if (timer == 60)
        {
            objectRenderer.material.SetColor("_Color", terrainColor);
        }

        if (timer== 59)
        {
            objectRenderer.material.SetColor("_Color", Color.red);
        }

        if (timer == 49)
        {
            objectRenderer.material.SetColor("_Color", terrainColor);
        }

        if (timer == 39)
        {
            objectRenderer.material.SetColor("_Color", Color.red);
        }

        if (timer == 29)
        {
            objectRenderer.material.SetColor("_Color", terrainColor);
        }

        if (timer == 19)
        {
            objectRenderer.material.SetColor("_Color", Color.red);
        }

        if (timer == 9)
        {
            objectRenderer.material.SetColor("_Color", terrainColor);
        }


        if (timer== 0)
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
