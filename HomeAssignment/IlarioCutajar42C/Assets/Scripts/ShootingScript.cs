using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    //properties
    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] float bulletCounter;
    [SerializeField] float enemyBulletSpeed;
    [SerializeField] bool isFiring;

    //Effects
    [SerializeField] AudioClip gunShotSound;
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
    void Update()
    {
        checkIfFiring();
    }


    private void Fire()
    {
        GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity) as GameObject;

        AudioSource.PlayClipAtPoint(gunShotSound, Camera.main.transform.position, gunShotVolume);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyBulletSpeed);
    }

    private void checkIfFiring()
    {
        if (isFiring == true)
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0f)
            {
                Fire();
                shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
            }
        }
    }
}
