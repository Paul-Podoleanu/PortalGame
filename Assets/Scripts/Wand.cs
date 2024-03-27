using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    [SerializeField]
    Transform bulletSpawnPoint;
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float bulletSpeed = 10f;

    void Update()
{
    /*
    if (Input.GetMouseButtonDown(0))
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = bulletSpawnPoint.forward * bulletSpeed;
    }*/

  //When Q is presset, the player will shoot a bullet
    if (Input.GetKeyDown(KeyCode.Q))
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

        //Wait for 2 seconds then destroy the bullet
        Destroy(bullet, 2);
    }
}

}

