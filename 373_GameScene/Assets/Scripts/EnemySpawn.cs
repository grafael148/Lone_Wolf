using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    // tracks time between enemy spawns
    public float spawnTime = 5f;
    private float nextSpawnTime = 0f;

    // references the player's position to Enemy during spawning
    public Transform player; 

    

    // Update is called once per frame
    void Update()
    {
        // tracks the time between spawns
        nextSpawnTime += Time.deltaTime;
        if (nextSpawnTime >= spawnTime)
        {
            spawnEnemy(player);
            updateSpawnTimer();
            nextSpawnTime = 0f;

        }
    }

    private void spawnEnemy(Transform player)
    {
        GameObject enemyGameObject = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        // adds the enemy movement script to the spanwed enemy
        EnemyMovement_AI enemyScript = enemyGameObject.AddComponent<EnemyMovement_AI>();
        enemyScript.player = player;
    }

    private void updateSpawnTimer()
    {
        spawnTime *= .9f; 
    }
}
