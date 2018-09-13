using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 4f); //destroys the enemy death fx after given time
    
	}	
}
