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
    public Animator animator;
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
        if (AttemptMove(x, y + 1))
        {
            SetAnimationState("MoveUp");
        }
    }

    private void MoveDown()
    {
        if (AttemptMove(x, y - 1))
        {
            SetAnimationState("MoveDown");
        }
    }

    private void MoveLeft()
    {
        if (AttemptMove(x - 1, y))
        {
            SetAnimationState("MoveRight");
        }
    }

    private void MoveRight()
    {
        if (AttemptMove(x + 1, y))
        {
            SetAnimationState("MoveLeft");
        }
    }

    private bool AttemptMove(int newX, int newY)
    {
        if (newX < 0 || newX >= GridManager.Instance.Grid.GetX() || newY < 0 || newY >= GridManager.Instance.Grid.GetY())
        {
            Debug.Log("Cannot move out of bounds");
            return false;
        }

        // Check for obstacles using Physics2D.OverlapCircle
        Vector2 targetPosition = GridManager.Instance.Grid.GetGridCenterPosition(newX, newY);
        Collider2D obstacle = Physics2D.OverlapCircle(targetPosition, 0.4f, obstacleLayer); // Adjust radius as needed

        if (obstacle != null)
        {
            Debug.Log("Obstacle detected at: " + newX + ", " + newY + " - Cannot move.");
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

    private void SetAnimationState(string activeState)
    {
        // Reset all movement-related animation states
        animator.SetBool("MoveUp", false);
        animator.SetBool("MoveDown", false);
        animator.SetBool("MoveLeft", false);
        animator.SetBool("MoveRight", false);

        animator.SetBool(activeState, true);

        StartCoroutine(SetIdleAfterMovement());
    }

    private IEnumerator SetIdleAfterMovement()
    {
        yield return new WaitForSeconds(1f); // Adjust delay to match movement animation duration
        ResetAnimationStates();
    }

    private void ResetAnimationStates()
    {
        // Reset all animation states to idle
        animator.SetBool("MoveUp", false);
        animator.SetBool("MoveDown", false);
        animator.SetBool("MoveLeft", false);
        animator.SetBool("MoveRight", false);
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
        animator.SetTrigger("IsDead"); // Trigger death animation
        StartCoroutine(HandleDeath());
    }

    private IEnumerator HandleDeath()
    {
        // Wait for the death animation to complete
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);

        // Invoke the onPlayerDeath event after animation
        onEnemyDeath?.Invoke();
        Debug.Log("Player received damage and is out of health.");
    }
}
