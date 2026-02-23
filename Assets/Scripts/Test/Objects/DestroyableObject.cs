using UnityEngine;

public class DestroyableObject : MonoBehaviour, IDamageable
{
    // Detect collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionEnter");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GetDamage();
            Debug.Log("Destroy");
            Destroy(collision.gameObject);
        }
    }

    public void GetDamage()
    {
        Destroy(gameObject);
    }

}
