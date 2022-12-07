using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathmenuempty : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("SnakeGame");
    }
}