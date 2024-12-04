using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;
    public float bulletSpeed = 10f;
    public float shootCooldown = 1f; 
    private float nextShotTime = 0f; 

    public enum ShootingDirection 
    {
        Left,
        Right 
    }
    public ShootingDirection shootDirection = ShootingDirection.Right; 

    private void Shoot(float lifeTime)
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        float directionMultiplier = (shootDirection == ShootingDirection.Right) ? 1f : -1f;
        rb.velocity = muzzle.right * bulletSpeed * directionMultiplier;

        Destroy(bullet, lifeTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextShotTime)
        {
            Shoot(10); 
            nextShotTime = Time.time + shootCooldown; 
        }
    }
}
