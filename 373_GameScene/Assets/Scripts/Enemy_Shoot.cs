using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
    [SerializeField] private float timer = 5f;
    private float bulletTime;

    public GameObject EnemyBullet;
    public Transform spawnPoint;
    public float EnemySpeed;

    private void Update()
    {
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime <= 0)
        {
            

            Debug.Log("shooting enemy");
            GameObject bulletObj = Instantiate(EnemyBullet, spawnPoint.position, spawnPoint.rotation) as GameObject;
            Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();

            bulletRig.AddForce(bulletRig.transform.forward * EnemySpeed);
            bulletTime = timer; // resets timer
            //Destroy(bulletObj, 5f); // destroy after 5 seconds
        }

        
    }
}
