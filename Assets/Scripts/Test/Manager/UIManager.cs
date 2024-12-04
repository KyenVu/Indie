using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] Button[] menuButtons;
    [SerializeField] Button[] restartButtons;
    [SerializeField] Button nextLevelButton;


    private void OnEnable()
    {
        Character.onPlayerDeath += LosePanelPopUp;
        Enemy.onEnemyDeath += WinPanelPopUp;
    }

    private void OnDisable()
    {
        Character.onPlayerDeath -= LosePanelPopUp;
        Enemy.onEnemyDeath -= WinPanelPopUp;
    }
    private void Start()
    {

        foreach (Button menuButton in menuButtons)
        {
            menuButton.onClick.AddListener(onMenuButtonClick);
        }

        foreach (Button restartButton in restartButtons)
        {
            restartButton.onClick.AddListener(onRestartLevelButtonClick);
        }

        nextLevelButton.onClick.AddListener(onNextLevelButtonClick);
    }

    private void WinPanelPopUp()
    {
        winPanel.SetActive(true);
    }

    private void LosePanelPopUp()
    {
        losePanel.SetActive(true);
    }

    public void onNextLevelButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void onRestartLevelButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onMenuButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }

}
