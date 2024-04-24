using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 200;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DamageTaken(int DamageAmount)
    {
        //reduces health
        maxHealth -= DamageAmount;

        if (maxHealth <= 0)
        {
            Debug.Log("enemy Killed");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            DamageTaken(50);
        }

        if (other.gameObject.tag == "Grenade")
        {
            DamageTaken(100);
        }
    }
}
