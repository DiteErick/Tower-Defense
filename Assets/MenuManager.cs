using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void OnGameButtonClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
    public void OnLevelButtonClicked(string level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
}
