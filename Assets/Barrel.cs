using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Damageable, ITakeDamage
{
    private int maxHealth = 20;
    [SerializeField]
    GameObject deathFX;
    private int health;
    [SerializeField]
    Transform parent;

    void Awake() {
        health = maxHealth;
    }

    public void TakeDamage(int damage) 
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death() {
        //this creates explosion in the place of enemy ships when they get destroyed
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
