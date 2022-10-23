using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float bulletForce = 20f;

    public Transform firePoint;

    public GameObject bulletPrefab;
    private float shootDelay = 1f;
    private float timeBetweenShots = 0;

    void Update()
    {
        timeBetweenShots += Time.deltaTime;
        if (
            !GameController.paused &&
            ((Input.GetButtonDown("Fire1")) || (Input.GetKeyDown("space"))) &&
            (timeBetweenShots >= shootDelay)
        )
        {
            GetComponent<AudioSource>().Play();    
            Shoot();
        }
    }

    // Create the bullet and send it flying
    void Shoot()
    {
        timeBetweenShots = 0;
        GameObject bullet =
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
