using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToggle : MonoBehaviour
{
    public bool pauseGameOnAwake;
    public static bool isInputEnabled = true;

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
        isInputEnabled = false;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        isInputEnabled = true;
    }
}
