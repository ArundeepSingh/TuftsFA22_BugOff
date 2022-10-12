using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int bugsExterminated = 0;

    public GameObject pauseMenu;

    public static bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        bugsExterminated = 0;

        if (GameObject.Find("PauseMenu") != null)
        {
            pauseMenu = GameObject.Find("PauseMenu");
            pauseMenu.SetActive(false);
        }

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused && Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
        else if (paused && Input.GetKeyDown(KeyCode.P))
        {
            UnPauseGame();
        }
    }

    public void PauseGame()
    {
        paused = true;
        if (!pauseMenu && GameObject.Find("PauseMenu") != null)
        {
            pauseMenu = GameObject.Find("PauseMenu");
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(true);
        }
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        paused = false;
        if (!pauseMenu && GameObject.Find("PauseMenu") != null)
        {
            pauseMenu = GameObject.Find("PauseMenu");
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
        Time.timeScale = 1;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadMainMenu()
    {
        paused = false;
        SceneManager.LoadScene("StartScene");
    }

    public void IncrementExterminatedBugs()
    {
        bugsExterminated += 1;
    }
}
