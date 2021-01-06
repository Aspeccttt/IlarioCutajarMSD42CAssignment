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
    //[SerializeField] GameObject deathEffect;
    //[SerializeField] float explosionDuration = 1f;

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
        //checkIfFiring();
    }


    //FIRE CODE (MAKE SURE TO UNCOMMENT IN UPDATE() [[fires currently]]
    private void Die()
    {
        Destroy(gameObject);

        //add code to add EFFECTS AND SOUND + DECREASE POINTS LATER
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity) as GameObject;

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
