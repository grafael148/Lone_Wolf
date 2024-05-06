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
    public string playerTag = "Player";
    private bool isPlayerHit;
    
    void Update()
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
            Transform currentPlayer = GameObject.FindGameObjectWithTag(playerTag).transform; // access the players current position 

            if (Physics.Raycast(transform.position, currentPlayer.position - transform.position, out hit, Mathf.Infinity))
            {
                
                if (hit.collider.gameObject == currentPlayer.gameObject)
                {
                    Debug.Log("hit colliding with player");
                    isPlayerHit = true;
                }

                Debug.DrawLine(transform.position, hit.point, Color.red, 1f);
            }

           if (isPlayerHit)
           {
               
                Debug.Log("Enemy Is Shooting");
                GameObject bulletObj = Instantiate(EnemyBullet, spawnPoint.position, spawnPoint.rotation) as GameObject;
                Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();

                // enemy shoots at the players position
                Vector3 direction = currentPlayer.position - transform.position;
                bulletRig.AddForce(direction * EnemySpeed);
                bulletTime = timer; // resets timer
                Destroy(bulletObj, 5f); // destroy after 5 seconds

                isPlayerHit = false;

           }

            
        }

        
    }
}
