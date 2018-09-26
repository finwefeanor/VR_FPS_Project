using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Damagable
{
    [SerializeField]
    GameObject deathFX;
    [SerializeField]
    Transform parent;

    private void Death() {
        //this creates explosion in the place of enemy ships when they get destroyed
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
