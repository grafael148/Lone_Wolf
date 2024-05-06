using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement_AI : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("enemy is moving");
        agent.destination = player.position;
    }

    public EnemyMovement_AI(Transform player)
    {
        
        this.player = player;
        
    }
}
