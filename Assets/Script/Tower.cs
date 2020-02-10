using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] float attackRange = 10f;
    [SerializeField] ParticleSystem projectile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);//make turret aim to the enemy automatically
            FireAtEnemy();
        }
        else 
        {
            Shoot(false);
        }
    }

    private void FireAtEnemy()
    {
        float distance = Vector3.Distance(objectToPan.position, targetEnemy.position);
        if (distance <= attackRange)
        {
            Shoot(true);
        }
        else 
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectile.emission;
        emissionModule.enabled = isActive;

    }
}
