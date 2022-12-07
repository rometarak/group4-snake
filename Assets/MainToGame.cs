using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainToGame : MonoBehaviour
{
    public void SnakeGame()
    {
        SceneManager.LoadScene("SnakeGame");
    }

    public void QuitGame()
    {
        Debug.Log("Mäng läks kinni!");
        Application.Quit();
    }
}