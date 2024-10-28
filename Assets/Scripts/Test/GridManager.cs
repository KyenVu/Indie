using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    public Character character;
    private Grid grid;
    public Grid Grid => grid;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(3, 3, 1);

        InitCharacter();
    }

    private void InitCharacter()
    {        // modify this value for init position of character/enemy
        int startX = 0, startY = 0;
        character.SetInitPosition(startX, startY);
        character.transform.position = grid.GetGridCenterPosition(startX, startY);
    }
}
