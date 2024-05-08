using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class _Magnum : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    // only shoots when this is set to true.
    private bool isPickedUp = false;

    private int currentAmmo = 7;
    private int maxAmmo = 7;

    public Transform attachPoint;
    

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo > 0 && isPickedUp && Input.GetMouseButtonDown(0))
        {
            Debug.Log ("shoot");
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
            currentAmmo--;
        }

        //Reload
        if ( Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
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
            // GetComponent<Rigidbody>().isKinematic = true;

            transform.parent = attachPoint;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPickedUp = false;
            //GetComponent <Rigidbody>().isKinematic = false;

            transform.parent = null;
        }
    }


}
