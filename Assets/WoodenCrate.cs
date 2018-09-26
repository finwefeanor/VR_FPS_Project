using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenCrate : Damagable
{
    public GameObject destroyedVersion;

    public void DamagedCrate(int damage) 
    {
        if(health <= 0)
        Instantiate(destroyedVersion, transform.position, transform.rotation);
    }
}
