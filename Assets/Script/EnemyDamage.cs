using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoint = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProccesHitPoints();
    }

    private void ProccesHitPoints()
    {
        hitPoint--;// hitpoint = hitpoint - 1
        if (hitPoint < 1)//if 0
        {
            Destroy(gameObject); //kill Enemy
        }

        //TODO particle when dying(1) and explode praticle
    }
}
