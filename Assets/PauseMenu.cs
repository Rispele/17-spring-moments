using System;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseGameMenu;
    [SerializeField] private GameObject settingsMenu;
    
    private EscapeManager escapeManager;

    private void Start()
    {
        escapeManager = GameObject.FindGameObjectWithTag("EscapeManager").GetComponent<EscapeManager>();
        escapeManager.ifToCloseStackEmpty.Add(Pause);
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        escapeManager.AddCloseTask(Resume);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneTransition.SwitchToScene("Menu");
    }

    public void LoadSettings()
    {
        settingsMenu.SetActive(true);
        escapeManager.AddCloseTask(() => settingsMenu.SetActive(false));
    }
}
