using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {

    int health;
    Text healthText;

    PlayerHealth playerHealth;

    void Start () {
        healthText = GetComponent<Text>();
        playerHealth = GetComponentInParent<PlayerHealth>();
        
	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = "Health: " + playerHealth.currentHealth.ToString();
    }
}
