using UnityEngine;
using UnityEngine.UI;

public class GridMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float gridSize = 1f;

    public Button moveUp;
    public Button moveDown;
    public Button moveLeft;
    public Button moveRight;

    private Vector3 targetPosition; 
    private bool isMoving;          

    void Start()
    {
        targetPosition = transform.position;
        moveUp.onClick.AddListener(MoveUp);
        moveDown.onClick.AddListener(MoveDown);
        moveLeft.onClick.AddListener(MoveLeft);
        moveRight.onClick.AddListener(MoveRight);
    }

    void Update()
    {
        if (isMoving)
        {
            MoveToTarget(); 
        }
    }

    public void MoveUp()
    {
        Move(Vector3.up);
    }

    public void MoveDown()
    {
        Move(Vector3.down);
    }

    public void MoveLeft()
    {
        Move(Vector3.left);
    }

    public void MoveRight()
    {
        Move(Vector3.right);
    }

    private void Move(Vector3 direction)
    {
        if (isMoving) return; 

        targetPosition = (Vector3)transform.position + direction * gridSize;
        isMoving = true;
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            transform.position = targetPosition;
            isMoving = false; 
        }
    }
}
