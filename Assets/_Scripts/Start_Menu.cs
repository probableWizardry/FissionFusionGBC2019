using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Start_Menu : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("closed game");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("loaded next scene");
    }
}
