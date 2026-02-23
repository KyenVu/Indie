using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Level Configuration")]
    [Tooltip("Buttons corresponding to levels in the UI")]
    public Button[] levelButtons;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        InitializeLevelStates();
    }

    public void InitializeLevelStates()
    {
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found!");
            return;
        }

        int unlockedLevels = gameManager.GetUnlockedLevels();
        Debug.Log($"[LevelManager] Unlocked Levels: {unlockedLevels}");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 <= unlockedLevels)
            {
                levelButtons[i].interactable = true; // Enable unlocked levels
                Debug.Log($"[LevelManager] Level {i + 1} is UNLOCKED.");
            }
            else
            {
                levelButtons[i].interactable = false; // Disable locked levels
                Debug.Log($"[LevelManager] Level {i + 1} is LOCKED.");
            }
        }
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex > 0 && levelIndex <= levelButtons.Length)
        {
            Debug.Log($"[LevelManager] Loading Level {levelIndex}...");
            SceneManager.LoadScene("Level " + levelIndex);
        }
        else
        {
            Debug.LogError("[LevelManager] Invalid level index.");
        }
    }

    public void Return()
    {
        Debug.Log("[LevelManager] Returning to previous menu.");
        gameObject.SetActive(false);
    }
}
