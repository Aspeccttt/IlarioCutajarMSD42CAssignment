using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] int bulletDamage = 1;

    public int GetBulletDamage()
    {
        return bulletDamage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
