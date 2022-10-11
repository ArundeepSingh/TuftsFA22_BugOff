using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int bugsExterminated = 0;

    // Start is called before the first frame update
    void Start()
    {
        bugsExterminated = 0;
    }

    // Update is called once per frame
    void Update()
    {
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

    public void IncrementExterminatedBugs()
    {
        bugsExterminated += 1;
    }
}
