using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //Properties
    [SerializeField] GameObject enemyBulletPrefab;
    [SerializeField] bool isShooting;
    [SerializeField] float bulletCounter;
    [SerializeField] float enemyBulletSpeed;
    
    //Effects
    [SerializeField] GameObject deathEffect;
    [SerializeField] float explosionDuration = 1f;









    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
