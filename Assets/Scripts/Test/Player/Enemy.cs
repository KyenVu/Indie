using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamageable
{
    private int x, y;

    public Button moveUp;
    public Button moveDown;
    public Button moveLeft;
    public Button moveRight;

    public LayerMask obstacleLayer;

    public static event Action onEnemyDeath;

    public void SetInitPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
        MoveToPosition(); // Set initial position on the grid
    }

    private void Start()
    {
        moveUp.onClick.AddListener(MoveUp);
        moveDown.onClick.AddListener(MoveDown);
        moveLeft.onClick.AddListener(MoveLeft);
        moveRight.onClick.AddListener(MoveRight);
    }

    private void MoveUp()
    {
        AttemptMove(x, y + 1);
    }

    private void MoveDown()
    {
        AttemptMove(x, y - 1);
    }

    private void MoveLeft()
    {
        AttemptMove(x - 1, y);
    }

    private void MoveRight()
    {
        AttemptMove(x + 1, y);
    }

    private bool AttemptMove(int newX, int newY)
    {
        if (newX < 0 || newX >= GridManager.Instance.Grid.GetX() ||
            newY < 0 || newY >= GridManager.Instance.Grid.GetY())
        {
            Debug.Log("Cannot move out of bounds");
            return false;
        }

        Vector2 targetPosition = GridManager.Instance.Grid.GetGridCenterPosition(newX, newY);
        Collider2D obstacle = Physics2D.OverlapCircle(targetPosition, 0.4f, obstacleLayer);

        if (obstacle != null)
        {
            Debug.Log("Obstacle detected at: " + newX + ", " + newY);
            return false;
        }

        x = newX;
        y = newY;
        MoveToPosition();
        return true;
    }

    private void MoveToPosition()
    {
        transform.position = GridManager.Instance.Grid.GetGridCenterPosition(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GetDamage();
            Destroy(collision.gameObject);
        }
    }

    public void GetDamage()
    {
        HandleDeath();
    }

    private void HandleDeath()
    {
        onEnemyDeath?.Invoke();
        Debug.Log("Enemy received damage and is out of health.");
    }
}