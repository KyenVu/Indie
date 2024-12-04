using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool playerHasDied = false;

    private void OnEnable()
    {
        Character.onPlayerDeath += playerDeath;
        Enemy.onEnemyDeath += enemyDeath;
    }

    private void OnDisable()
    {
        Character.onPlayerDeath -= playerDeath;
        Enemy.onEnemyDeath -= enemyDeath;
    }

    private void playerDeath()
    {
        if (!playerHasDied)
        {
            playerHasDied = true; 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void enemyDeath()
    {
        if (!playerHasDied) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
