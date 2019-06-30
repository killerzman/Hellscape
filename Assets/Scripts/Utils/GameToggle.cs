using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToggle : MonoBehaviour
{
    public bool pauseGameOnAwake;

    private void Awake()
    {
        if (pauseGameOnAwake)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }
}
