using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;
    public Button shotButton;
    public int magazine;
    private int currentBullets;
    public float bulletSpeed = 10f;
    public float shootCooldown = 1f;
    private float nextShotTime = 0f;
    public float shotDelay = 0.2f;
    public Animator animator;

    public AudioClip shotSound; // Shot sound effect
    private AudioSource audioSource; // AudioSource component

    public enum ShootingDirection
    {
        Left,
        Right
    }
    public ShootingDirection shootDirection = ShootingDirection.Right;

    private void Start()
    {
        shotButton.onClick.AddListener(TryShoot);
        currentBullets = magazine;
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found on the game object!");
        }
    }

    private void TryShoot()
    {
        if (Time.time >= nextShotTime && currentBullets > 0)
        {
            animator.SetTrigger("shot");

            // Play the shot sound
            PlayShotSound();

            StartCoroutine(ShootAfterDelay());
            nextShotTime = Time.time + shootCooldown;
        }
        else if (currentBullets <= 0)
        {
            Debug.Log("Out of bullets");
        }
        else
        {
            Debug.Log("Cooldown active, wait to shoot again.");
        }
    }

    private IEnumerator ShootAfterDelay()
    {
        yield return new WaitForSeconds(shotDelay);

        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            Vector2 direction = (shootDirection == ShootingDirection.Right) ? Vector2.right : Vector2.left;
            bulletScript.Initialize(direction, bulletSpeed);
        }

        StartCoroutine(SetIdleAfterShooting());
    }

    private IEnumerator SetIdleAfterShooting()
    {
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("Idle");
    }

    private void PlayShotSound()
    {
        if (audioSource != null && shotSound != null)
        {
            audioSource.PlayOneShot(shotSound);
        }
        else
        {
            Debug.LogWarning("Shot sound or AudioSource is missing.");
        }
    }
}
