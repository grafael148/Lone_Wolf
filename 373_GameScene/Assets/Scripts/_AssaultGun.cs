using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _AssaultGun : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f; 
       
    // only shoots when this is set to true.
    private bool isPickedUp = false;

    // set clip size
    private int currentAmmo = 30;
    private int maxAmmo = 30;

    // settings for rate of fire
    public float fireRate = 0.1f;
    private bool isShooting = false;



    // Update is called once per frame
    void Update()
    {
        if (currentAmmo > 0 && isPickedUp)
        {
            // Shoots when mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                isShooting = true; 
                InvokeRepeating("Shoot", 0f, fireRate);
                
            }

            if (Input.GetMouseButtonUp(0))
            {
                isShooting = false;
                CancelInvoke("Shoot");
            }
            
        }

        //Reload
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
        {
            Reload();
        }


    }

    private void Shoot()
    {
        if (isShooting && currentAmmo > 0)
        {
            Debug.Log("shoot");
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
            currentAmmo--;
        }
        else
        {
            CancelInvoke("Shoot");
            isShooting = false;
        }

    }

    private void Reload()
    {
        int ammoNeeded = maxAmmo - currentAmmo;
        currentAmmo += ammoNeeded;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPickedUp = true;
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPickedUp = false;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
