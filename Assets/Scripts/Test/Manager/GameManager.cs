using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool playerHasDied = false;
    private int unlockedLevels;

    private void Awake()
    {
        // Load unlocked levels from PlayerPrefs or initialize with the first level unlocked
        unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);
        Debug.Log($"[GameManager] Loaded Unlocked Levels: {unlockedLevels}");
    }

    public int GetUnlockedLevels()
    {
        Debug.Log($"[GameManager] Returning Unlocked Levels: {unlockedLevels}");
        return unlockedLevels; // Expose unlocked levels to other scripts
    }

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
            Debug.Log("[GameManager] Player Died! Restarting Level...");
            playerHasDied = true;
        }
    }

    private void enemyDeath()
    {
        if (!playerHasDied)
        {
            Debug.Log("[GameManager] Enemy Defeated! Unlocking Next Level...");
            UnlockNextLevel(); // Handle level unlocking logic
        }
    }

    private void UnlockNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        Debug.Log($"[GameManager] Current Level: {currentLevel}, Unlocked Levels: {unlockedLevels}");

        if (currentLevel >= unlockedLevels)
        {
            unlockedLevels = currentLevel + 1; // Update unlocked levels
            PlayerPrefs.SetInt("UnlockedLevels", unlockedLevels);
            PlayerPrefs.Save();

            Debug.Log($"[GameManager] Next Level Unlocked: {unlockedLevels}");
        }
        else
        {
            Debug.Log($"[GameManager] Level {currentLevel} is already unlocked.");
        }
    }
}
