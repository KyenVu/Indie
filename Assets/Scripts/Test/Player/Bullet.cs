using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 direction;
    private float speed;

    public float lifetime = 5f;
    private bool canChangeDirection = true; 
    private float directionChangeCooldown = 0.3f; 

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    public void Initialize(Vector2 direction, float speed)
    {
        this.direction = direction.normalized; 
        this.speed = speed;
    }
    /// <summary>
    /// Initializes the bullet's movement parameters.
    /// </summary>
    /// <param name="direction">The direction the bullet will move in.</param>
    /// <param name="speed">The speed of the bullet.</param>
    public void SetDirection(Vector2 newDirection)
    {
        if (canChangeDirection)
        {
            direction = newDirection.normalized; 
            StartCoroutine(DirectionChangeCooldown());
        }
    }

    /// <summary>
    /// Prevents the bullet from changing direction for a certain cooldown period.
    /// </summary>
    private IEnumerator DirectionChangeCooldown()
    {
        canChangeDirection = false;
        yield return new WaitForSeconds(directionChangeCooldown);
        canChangeDirection = true;
    }
}
