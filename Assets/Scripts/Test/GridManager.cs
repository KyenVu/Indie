using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    public Character character;
    public Enemy enemy;
    private Grid grid;
    public Grid Grid => grid;

    public int startPlayerX, startPlayerY;
    public int startEnemyX, startEnemyY;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(16, 9, 1);

        InitCharacter();
    }

    private void InitCharacter()
    {        
        character.SetInitPosition(startPlayerX, startPlayerY);
        character.transform.position = grid.GetGridCenterPosition(startPlayerX, startPlayerY);

        enemy.SetInitPosition(startEnemyX, startEnemyY);
        enemy.transform.position = grid.GetGridCenterPosition(startEnemyX, startEnemyY);
    }
}
