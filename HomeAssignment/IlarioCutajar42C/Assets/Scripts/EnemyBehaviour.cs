using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //Properties
    [SerializeField] float enemyHP = 1;
    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] float bulletCounter;
    [SerializeField] float enemyBulletSpeed;
    
    //Effects
    [SerializeField] GameObject deathEffect;
    [SerializeField] float explosionDuration = 1f;
    [SerializeField] AudioClip gunShotSound;
    [SerializeField] AudioClip deathsound;
    [SerializeField] [Range(0, 1)] float enemyDeathSoundVolume = 0.60f;
    [SerializeField] [Range(0, 1)] float gunShotVolume = 0.40f;

    //Debugging
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;


    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    private void Update()
    {
        checkIfFiring();
    }


    //FIRE CODE (MAKE SURE TO UNCOMMENT IN UPDATE() [[fires currently]]
    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathsound, Camera.main.transform.position, enemyDeathSoundVolume);
        GameObject explosion = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(explosion, explosionDuration);
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity) as GameObject;

        AudioSource.PlayClipAtPoint(gunShotSound, Camera.main.transform.position, gunShotVolume);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyBulletSpeed);
    }

    private void checkIfFiring()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
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
