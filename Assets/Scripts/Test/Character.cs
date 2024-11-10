using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    private int x, y;

    public Button moveUp;
    public Button moveDown;
    public Button moveLeft;
    public Button moveRight;

    public void SetInitPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
        MoveToPosition(); // Set initial position on the grid
    }

    private void Start()
    {
        // Add listeners for each button
        moveUp.onClick.AddListener(MoveUp);
        moveDown.onClick.AddListener(MoveDown);
        moveLeft.onClick.AddListener(MoveLeft);
        moveRight.onClick.AddListener(MoveRight);
    }

    private void MoveUp()
    {
        int value = y + 1;
        if (value > GridManager.Instance.Grid.GetY() - 1)
        {
            Debug.Log("Y value cannot be more than grid size");
        }
        else
        {
            y = value;
            MoveToPosition();
        }
    }

    private void MoveDown()
    {
        int value = y - 1;
        if (value < 0)
        {
            Debug.Log("Y value cannot be less than 0");
        }
        else
        {
            y = value;
            MoveToPosition();
        }
    }

    private void MoveLeft()
    {
        int value = x - 1;
        if (value < 0)
        {
            Debug.Log("X value cannot be less than 0");
        }
        else
        {
            x = value;
            MoveToPosition();
        }
    }

    private void MoveRight()
    {
        int value = x + 1;
        if (value > GridManager.Instance.Grid.GetX() - 1)
        {
            Debug.Log("X value cannot be more than grid size");
        }
        else
        {
            x = value;
            MoveToPosition();
        }
    }

    private void MoveToPosition()
    {
        transform.position = GridManager.Instance.Grid.GetGridCenterPosition(x, y);
    }
}
