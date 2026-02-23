using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Button StartGameButton;
    public Button LevelMenuButton;
    public Button SettingButton;
    public Button QuitButton;

    public GameObject LevelMenuPanel;
    public GameObject SettingPanel;

    public LevelManager LevelManager;
    // Start is called before the first frame update
    void Start()
    {
        StartGameButton.onClick.AddListener(OnStartGameClick);
        LevelMenuButton.onClick.AddListener(OnOpenMenuClick);
        SettingButton.onClick.AddListener(OnSettingClick);
        QuitButton.onClick.AddListener(QuitGameClick);
        LevelMenuPanel.SetActive(false);
        SettingPanel.SetActive(false);
    }

    private void OnStartGameClick()
    {
        SceneManager.LoadScene("Level 1");
    }

    private void OnOpenMenuClick()
    {
        LevelManager.InitializeLevelStates();
        LevelMenuPanel.SetActive(true);
    }

    private void OnSettingClick()
    {
        SettingPanel.SetActive(true);
    }

    private void QuitGameClick()
    {
        Application.Quit();
    }
    public void Return()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
