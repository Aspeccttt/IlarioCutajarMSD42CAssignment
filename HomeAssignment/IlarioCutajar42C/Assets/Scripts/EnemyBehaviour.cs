using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EnemyBehaviour : MonoBehaviour
{
    //Properties
    [SerializeField] float enemyHP = 1;
    
    //Effects
    [SerializeField] GameObject deathEffect;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] AudioClip deathsound;
    [SerializeField] [Range(0, 1)] float enemyDeathSoundVolume = 0.60f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }


    //dead script
    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathsound, Camera.main.transform.position, enemyDeathSoundVolume);
        GameObject explosion = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(explosion, explosionDuration);
    }


    //Collision CODE
    private void ProcessHit(DamageDealer PlayerCollided)
    {
        enemyHP -= PlayerCollided.GetDamageDealerContent();

        if (enemyHP <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer PlayerCollided = collision.gameObject.GetComponent<DamageDealer>();

        ProcessHit(PlayerCollided);

        
    }

}
