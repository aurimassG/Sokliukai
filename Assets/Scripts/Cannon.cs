using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private float time = 0.0f;
    public float interpolationPeriod = 2.0f;

    void Update()
    {
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time -= interpolationPeriod;

            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletPrefab.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
        }
    }
}
