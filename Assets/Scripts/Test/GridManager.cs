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

    public int startX, startY;


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
        character.SetInitPosition(startX, startY);
        character.transform.position = grid.GetGridCenterPosition(startX, startY);
    }
}
