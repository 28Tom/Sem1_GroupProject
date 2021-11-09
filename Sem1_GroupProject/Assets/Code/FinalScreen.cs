using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScreen : MonoBehaviour
{
    public void MainMenuButton1()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGameButton1()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
