using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Start_Menu : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("I have Quit The Game");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("I have gone to the next scene");
    }
}
