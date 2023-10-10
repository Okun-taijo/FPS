using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;
    [SerializeField] private GameObject _pauseGameMenu;

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame == true)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Pause()
    {
        _pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }
    public void Continue()
    {
        _pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}

