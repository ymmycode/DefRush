using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoint = 3;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] ParticleSystem explodeParticles;

    // Start is called before the first frame update
    void Start()
    {
        if (explodeParticles.isPlaying){explodeParticles.Stop();}
    }

    private void OnParticleCollision(GameObject other)
    {
        if (hitParticles.isPlaying){hitParticles.Stop();}
        hitParticles.Play();
        ProccesHitPoints();
    }

    private void ProccesHitPoints()
    {
        hitPoint--;
        if (hitPoint <= 0)
        {
            explodeParticles.Play();
            Invoke("DestroyEnemy", 0.6f);
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
