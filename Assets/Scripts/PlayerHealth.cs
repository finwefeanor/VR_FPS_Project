using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] int startingHealth = 100;
    [SerializeField] AudioClip deathSound;
    public int currentHealth;

    AudioSource playerAudio;
    SceneLoader sceneLoader;
    CharacterController characterController;
    RifleFire rifleFire;
    bool isDead;                                                
    bool damaged;                                               

    void Start() 
    {
        playerAudio = GetComponent<AudioSource>();
        currentHealth = startingHealth;
        characterController = GetComponent<CharacterController>();
        rifleFire = GetComponentInChildren<RifleFire>();
    }

    public void TakeDamage(int amount) 
    {
        damaged = true;

        currentHealth -= amount;

        // Play the hurt sound effect.
        if (damaged)
        {
            playerAudio.Play();
        }

        StartCoroutine(MainSceneLevel());
    }

    IEnumerator MainSceneLevel() 
    {
        if (currentHealth <= 0 && !isDead)
        {
            PlayerDeath();
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(0);
            //yield return new WaitForSeconds(2f);
        }       
    } 

    void PlayerDeath() 
    {
        isDead = true;

        playerAudio.clip = deathSound;
        playerAudio.Play();

        rifleFire.enabled = false;
        characterController.enabled = false;
    }
}
