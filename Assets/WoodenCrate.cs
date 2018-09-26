using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenCrate : Damagable, IDestroy
{
    public GameObject destroyedVersion;

    public void DestroyObject(GameObject gameObject) {
        if (health <= 0)
        {
            Instantiate(destroyedVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
