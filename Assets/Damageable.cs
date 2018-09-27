﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour, ITakeDamage
{
    [SerializeField]  public int maxHealth;

    [SerializeField]  int scorePerHit = 12;

    ScoreBoard scoreBoard;

    public int health;

    private void Awake() {
        health = maxHealth;
    }

    void Start() {
        if (gameObject.GetComponent<BoxCollider>() == null && gameObject.GetComponent<MeshCollider>() == false)
        {
            AddBoxCollider();
        }
        else if (gameObject.GetComponent<Rigidbody>() == null)
        {
            AddRigidBody();
        }
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider() {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void AddRigidBody() {
        Rigidbody rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.isKinematic = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        DamageScore();
       
        if (health <= 0)
        {
            health = 0;
        }
    }

    private void DamageScore() 
    {
        scoreBoard.ScoreHit(scorePerHit);
    }

}