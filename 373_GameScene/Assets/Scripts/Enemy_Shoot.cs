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

    /// this code is so the enemy isn't constantly shooting when the player is behind walls.
    public Transform player;
    private bool isPlayerHit;
    
    private void Update()
    {
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime <= 0)
        {
            //this code is so the enemy isn't constantly shooting when the player is behind walls.
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.position - transform.position, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    isPlayerHit = true;
                }
            }

            if (isPlayerHit)
            {
               
                Debug.Log("Enemy Is Shooting");
                GameObject bulletObj = Instantiate(EnemyBullet, spawnPoint.position, spawnPoint.rotation) as GameObject;
                Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();

                // shoots at the player if on a ledge
                Vector3 direction = player.position - transform.position;
                bulletRig.AddForce(direction * EnemySpeed);
                bulletTime = timer; // resets timer
                Destroy(bulletObj, 5f); // destroy after 5 seconds

                isPlayerHit = false;

            }

            
        }

        
    }
}
