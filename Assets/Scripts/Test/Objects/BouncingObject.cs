using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingObject : MonoBehaviour
{
    public enum BulletDirectionChange
    {
        None,   
        Up,        
        Down,       
        Left,       
        Right       
    }

    public BulletDirectionChange changeDirection = BulletDirectionChange.None;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            ChangeBulletDirection(bullet);
        }
    }
    // Change bullets direction
    private void ChangeBulletDirection(Bullet bullet)
    {
        switch (changeDirection)
        {
            case BulletDirectionChange.Up:
                bullet.SetDirection(Vector2.up);
                break;
            case BulletDirectionChange.Down:
                bullet.SetDirection(Vector2.down);
                break;
            case BulletDirectionChange.Left:
                bullet.SetDirection(Vector2.left);
                break;
            case BulletDirectionChange.Right:
                bullet.SetDirection(Vector2.right);
                break;
            default:
                break;
        }
    }

}
