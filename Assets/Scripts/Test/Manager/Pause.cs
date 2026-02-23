using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    public void RestartLevel(int LevelIndex)
    {
        SceneManager.LoadScene("Level " + LevelIndex);
    }
    
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenPauseLevel()
    {
        gameObject.SetActive(true);
    }
    public void Return()
    {
        gameObject.SetActive(false);
    }

}
