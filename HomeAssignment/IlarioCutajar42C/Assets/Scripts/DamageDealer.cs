using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int bulletsDamage = 1;

    public int GetBulletDamage()
    {
        return bulletsDamage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
