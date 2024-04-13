using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Wand : MonoBehaviour
{
    [SerializeField]
    Transform bulletSpawnPoint;

    [SerializeField]
    GameObject firstPortalShotPrefab;

    [SerializeField]
    GameObject secondPortalShotPrefab;

    [SerializeField]
    float bulletSpeed = 10f;
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
      //When Q is presset, the player will shoot a bullet
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Vector3 spawnPosition = mainCamera.transform.position;
            Vector3 spawnDirection = mainCamera.transform.forward;

            GameObject bullet = Instantiate(firstPortalShotPrefab, bulletSpawnPoint.position, Quaternion.identity);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = spawnDirection * bulletSpeed;

            //Wait for 2 seconds then destroy the bullet
            Destroy(bullet, 2);
        }

        //When E is pressed, the player will shoot a bullet
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Vector3 spawnPosition = mainCamera.transform.position;
            Vector3 spawnDirection = mainCamera.transform.forward;

            GameObject bullet = Instantiate(secondPortalShotPrefab, bulletSpawnPoint.position, Quaternion.identity);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = spawnDirection * bulletSpeed;

            //Wait for 2 seconds then destroy the bullet
            Destroy(bullet, 2);
        }
    }

}

