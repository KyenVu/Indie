using UnityEngine;

public class DestroyableObject : MonoBehaviour, IDamageable
{
    // Detect collision
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
        Destroy(gameObject);
    }

}
