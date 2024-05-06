using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 50f;
    // only shoots when this is set to true.
    private bool isPickedUp = false;

    private int currentAmmo = 4;
    private int maxAmmo = 4;



    // Update is called once per frame
    void Update()
    {
        if (currentAmmo > 0 && isPickedUp && Input.GetMouseButtonDown(0))
        {
            Debug.Log("shoot");
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
            currentAmmo--;
        }

        //Reload
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
        {
            Reload();
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
