using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    //properties
    [SerializeField] public int health = 50;
    [SerializeField] float playerMoveSpeed = 5f;
    [SerializeField] float playerPadding = 0.7f;

    [SerializeField] AudioClip deathsound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.60f;
    [SerializeField] GameObject deathEffect;
    [SerializeField] float explosionDuration = 1f;

    //variables for movement.
    float xMin, xMax;

    // Start is called before the first frame update
    void Start()
    {
        Boundries();
    }

    // Update is called once per frame
    void Update()
    {
        MoveControls();
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetHealthEnd(int healthEnd)
    {
        return health;
    }

    private void Die()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathsound, Camera.main.transform.position, deathSoundVolume);
        GameObject explosion = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(explosion, explosionDuration);

        FindObjectOfType<Level>().LoadGameOver();
    }


    //MOVEMENT CODE SECTION -------------------------------------------------------------
    private void Boundries()
    {
        Camera Border = Camera.main;

        //xMin= 0 xMax = 1
        xMin = Border.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + playerPadding;
        xMax = Border.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - playerPadding;
    }
    private void MoveControls()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playerMoveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        this.transform.position = new Vector2(newXPos, - 3);
    }
    //-------------------------------------------------------------------------------------



    //damage handler CODE SECTION ---------------------------------------------------------------------

    private void ProcessHit(DamageDealer dmgDealer, BulletDamage bulletDamage)
    {
        health -= dmgDealer.GetDamageDealerContent();

        if (health <= 0)
        {
            FindObjectOfType<GameSession>().AddToHealth(scoreValue);
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer dmgDealer = collision.gameObject.GetComponent<DamageDealer>();
        BulletDamage bltDealer = collision.gameObject.GetComponent<BulletDamage>();

        ProcessHit(dmgDealer,bltDealer);
    }

}


