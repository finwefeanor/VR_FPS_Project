using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern 
{

}
public class DangerZone : MonoBehaviour {

    public float timeBetweenAttacks = 0.5f;     // The time in seconds between each attack.
    public int attackDamage = 10;               

    GameObject player;                          
    PlayerHealth playerHealth;  
    bool playerInRange;                         // player is within the trigger collider or not
    float timer;

    void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update() {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
        }

        if (playerHealth.currentHealth <= 0)
        {
            print("PlayerDead");
        }
    }

    void Attack() {
        // Reset the timer.
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

}
