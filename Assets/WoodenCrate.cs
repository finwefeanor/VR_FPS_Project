using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenCrate : Damageable
{
    public GameObject destroyedVersion;

    public void DestroyedCrate() {
        
    }

    public void DamagedCrate() 
    {
        if (health <= 0)
        {
            print("this is working");
            //Instantiate(destroyedVersion, transform.position, transform.rotation);
            //Destroy(gameObject);
        }
    }


}
