using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] Transform parent;
    ScoreBoard scoreBoard;
    [SerializeField] float health = 50f;


    void Start() 
    {
        if (gameObject.GetComponent<BoxCollider>() == null && gameObject.GetComponent<MeshCollider>() == false)
        {
            AddBoxCollider();
        }
        if (gameObject.GetComponent<Rigidbody>() == null)
        {
            AddRigidBody();
        }
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider() {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    private void AddRigidBody() 
    {
        Rigidbody rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.isKinematic = false;
    }

    public void KillDamage (float amount) 
    {
        ProcessHit();
        health -= amount; // or health = health - amount;

        if (health <= 0f)
        {
            Death();
        }
    }

    private void ProcessHit() {
        //call ScoreHit from ScoreBoard class
        scoreBoard.ScoreHit(scorePerHit);
        
    }

    private void Death() 
    {
        //this creates explosion in the place of enemy ships when they get destroyed
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
