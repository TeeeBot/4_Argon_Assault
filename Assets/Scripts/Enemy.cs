
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX = default;
    [SerializeField] Transform parent = default;
    [SerializeField] int pointsPerHit = 10;
    [SerializeField] int hitsRemaining = 4;

    ScoreBoard scoreBoard;

    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider myBoxCollider = gameObject.AddComponent<BoxCollider>();
        myBoxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision(GameObject other) //gives you the GameObject it has collided with
    {
        ProcessHit();

        if (hitsRemaining <= 0)
        {
            KillEnemy();
        }

    }

    private void ProcessHit()
    {
        scoreBoard.ScoreHit(pointsPerHit);
        hitsRemaining--;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
