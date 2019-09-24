using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamewin : MonoBehaviour
{
    private float winDelay = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Defaultplayer")
        {
            Time.timeScale = .25f;
            Invoke("Win", winDelay);
        }
    }

    public void Win()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}