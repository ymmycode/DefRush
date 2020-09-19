using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoint = 3;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] ParticleSystem explodeParticles;
    [SerializeField] AudioClip[] sfx;

    // Start is called before the first frame update
    void Start()
    {
        if (explodeParticles.isPlaying){explodeParticles.Stop();}
    }

    private void OnParticleCollision(GameObject other)
    {
        if (hitParticles.isPlaying){hitParticles.Stop();}
        hitParticles.Play();
        GetComponent<AudioSource>().PlayOneShot(sfx[0]);
        ProccesHitPoints();
    }

    private void ProccesHitPoints()
    {
        hitPoint--;
        if (hitPoint <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GetComponent<AudioSource>().PlayOneShot(sfx[1]);
        FindObjectOfType<EnemySpawner>().score += 10;
        GetComponent<EnemyMovement>().enemyBody.SetActive(false);
        explodeParticles.Play();
        float secDelay = explodeParticles.main.duration;
        Destroy(gameObject, secDelay);
    }
}
