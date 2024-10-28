using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int x, y;

    public void SetInitPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int value = x - 1;
            if (value < 0)
            {
                Debug.Log("X value cannot less than 0");
            }
            else
            {
                x = value;
                MoveToPosition();
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            int value = y - 1;
            if (value < 0)
            {
                Debug.Log("Y value cannot less than 0");
            }
            else
            {
                y = value;
                MoveToPosition();
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            int value = x + 1;
            if (value > GridManager.Instance.Grid.GetX() - 1)
            {
                Debug.Log("X value cannot more than grid size");
            }
            else
            {
                x = value;
                MoveToPosition();
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            int value = y + 1;
            if (value > GridManager.Instance.Grid.GetY() - 1)
            {
                Debug.Log("Y value cannot more than grid size");
            }
            else
            {
                y = value;
                MoveToPosition();
            }
        }
    }

    private void MoveToPosition()
    {
        transform.position = GridManager.Instance.Grid.GetGridCenterPosition(x, y);
    }
}
