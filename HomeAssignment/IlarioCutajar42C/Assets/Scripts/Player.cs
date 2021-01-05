using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //properties
    [SerializeField] float health = 50;
    [SerializeField] float playerMoveSpeed = 5f;
    [SerializeField] float playerPadding = 0.7f;

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

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer bulletsDamage = otherObject.gameObject.GetComponent<DamageDealer>();
        WaveConfiguration currentWaveDamage = otherObject.gameObject.GetComponent<WaveConfiguration>();

        if (!bulletsDamage)
        {
            return;
        }

        if (!currentWaveDamage)
        {
            return;
        }

        LoadBulletDamage(bulletsDamage);
        LoadCollisionDamage(currentWaveDamage);

    }

    private void LoadBulletDamage(DamageDealer bulletsDamage)
    {
        health -= bulletsDamage.GetBulletDamage();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void LoadCollisionDamage(WaveConfiguration currentWaveDamage)
    {
        health -= currentWaveDamage.FetchTheCurrentDamageOfWave();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }



}


