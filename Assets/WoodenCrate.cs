using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenCrate : Damageable, ITakeDamage
{
    public GameObject destroyedVersion;        

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0)
        {
            DamagedCrate();
        }
    }

    public void DamagedCrate() {
        if (health <= 0)
        {
            print("this is working");
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
