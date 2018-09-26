using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnClick : MonoBehaviour {

	// Update is called once per frame
	void Update () 
    {
	    if (Input.GetMouseButtonDown(0))
        {
            var damageables = FindObjectsOfType<Damagable>();
            foreach (var damageable in damageables)
            {
                damageable.TakeDamage(1);
                //no matter where i click, every damageable object  
                //will take 1 damage.
            }
        }	
	}
}
