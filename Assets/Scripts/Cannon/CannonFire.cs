using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    public GameObject projectilePrefab; 
    public Transform spawnPoint; 
    public float fireRate = 10f; 
    private float timeSinceLastShot = 0f;

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= fireRate)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
