using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneTransition.SwitchToScene("Intro");
    }

    public void QuitGame()
    {
        Debug.Log("Выход из игры завершен");
        Application.Quit();
    }
}
