
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX = default;
    [SerializeField] Transform parent = default;
    [SerializeField] int pointsForDestroying = 10;

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
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
        scoreBoard.ScoreHit(pointsForDestroying);
    }
}
