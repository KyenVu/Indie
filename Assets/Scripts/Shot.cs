using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;
    public float bulletSpeed;
    // Start is called before the first frame update
    private void Shoot(float lifeTime)
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); 
        rb.velocity = muzzle.right * bulletSpeed;
        Destroy(bullet, lifeTime);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(5);
        }
    }
}
