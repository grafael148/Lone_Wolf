using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth; 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DamageTaken(int damageAmount)
    {
        // reduces health by damage taken
        currentHealth -= damageAmount; 

        // checks to see if player health is zero.
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over!");
            StopPlayer();
        }
    }

    private void StopPlayer()
    {
        // disables character movement
        GetComponent<CharacterController>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            DamageTaken(10);
        }

        if (other.gameObject.tag == "HealthPickUp")
        {
            currentHealth += 20;
            Destroy(other.gameObject);
        }
            


    }
}
