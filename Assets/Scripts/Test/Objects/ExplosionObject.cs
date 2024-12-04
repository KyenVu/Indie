using UnityEngine;

public class ExplosionObject : MonoBehaviour
{
    public float explosionRadius = 5f; // Radius of the explosion
    public LayerMask destroyableLayer; // Set this in the inspector to filter which objects to destroy
    private bool hasExploded = false;  // Prevents multiple explosions of the same object

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Explode(); // Trigger explosion
            Destroy(collision.gameObject);
        }
    }

    public void Explode()
    {
        if (hasExploded) return; // Prevent re-explosion
        hasExploded = true;

        // Find all objects within the explosion radius
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, explosionRadius, destroyableLayer);

        // Loop through the detected objects and destroy them or trigger their explosion
        foreach (Collider2D obj in objectsInRange)
        {
            if (obj.CompareTag("ExplosionObject")) // Check if the object is another explosion
            {
                obj.GetComponent<ExplosionObject>()?.Explode(); // Trigger the explosion on nearby objects
            }
            else
            {
                Destroy(obj.gameObject); // Destroy other objects in range
            }
        }

        // Optional: Destroy the explosion object itself after the explosion
        Destroy(gameObject);
    }

    // Visualize the explosion radius in the editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
