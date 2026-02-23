using UnityEngine;
using System.Collections;

public class ExplosionObject : MonoBehaviour
{
    public float explosionRadius = 7f;
    public LayerMask destroyableLayer;
    public float explosionDelay = 0.2f; // Delay for chain explosions
    public GameObject[] explosionEffectPrefabs; // Array of particle effect prefabs
    private bool hasExploded = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TriggerExplosion();
            Destroy(collision.gameObject);
        }
    }

    public void TriggerExplosion()
    {
        if (hasExploded) return;
        hasExploded = true;

        // Start the explosion process
        StartCoroutine(ExplosionSequence());
    }

    private IEnumerator ExplosionSequence()
    {
        // Spawn and play all particle effects
        foreach (GameObject effectPrefab in explosionEffectPrefabs)
        {
            if (effectPrefab != null)
            {
                GameObject spawnedEffect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                ParticleSystem ps = spawnedEffect.GetComponent<ParticleSystem>();

                if (ps != null)
                {
                    ps.Play();
                    Destroy(spawnedEffect, ps.main.duration + ps.main.startLifetime.constantMax); 
                }
                else
                {
                   
                    Destroy(spawnedEffect, 1f);
                }
            }
        }

        // Wait for the longest particle effect to finish
        yield return new WaitForSeconds(0.3f);

        // Trigger the explosion damage
        Explode();
    }

    public void Explode()
    {
        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(transform.position, explosionRadius, destroyableLayer);

        foreach (Collider2D obj in objectsInRange)
        {
            if (obj.CompareTag("ExplosionObject"))
            {
                // Trigger chain explosion with a delay
                obj.GetComponent<ExplosionObject>()?.TriggerExplosionWithDelay(explosionDelay);
            }
            else
            {
                IDamageable damageable = obj.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.GetDamage();
                }
                else
                {
                    Destroy(obj.gameObject);
                }
            }
        }

        Destroy(gameObject);
    }

    public void TriggerExplosionWithDelay(float delay)
    {
        if (hasExploded) return;
        hasExploded = true;

        StartCoroutine(ExplosionSequenceWithDelay(delay));
    }

    private IEnumerator ExplosionSequenceWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(ExplosionSequence());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
