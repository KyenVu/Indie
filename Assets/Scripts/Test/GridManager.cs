using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    public Character character;
    public Enemy enemy;

    private Grid grid;
    public Grid Grid => grid;

    [Header("Grid Settings")]
    public int gridWidth = 16;
    public int gridHeight = 7;
    public float cellSize = 1;

    [Header("Start Player Positions")]
    public int startPlayerX;
    public int startPlayerY;
    [Header("Start Enemy Positions")]
    public int startEnemyX;
    public int startEnemyY;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        grid = new Grid(gridWidth, gridHeight, cellSize);

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
