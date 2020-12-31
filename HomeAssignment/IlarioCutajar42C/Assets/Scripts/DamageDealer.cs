using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] int wave1Damage = 1;
    [SerializeField] int wave2Damage = 2;
    [SerializeField] int wave3Damage = 3;
    [SerializeField] int wave4Damage = 4;
    [SerializeField] int wave5Damage = 5;
    [SerializeField] int bulletsDamage = 1;

    public int GetWave1Damage()
    {
        return wave1Damage;
    }

    public int GetWave2Damage()
    {
        return wave2Damage;
    }

    public int GetWave3Damage()
    {
        return wave3Damage;
    }

    public int GetWave4Damage()
    {
        return wave4Damage;
    }

    public int GetWave5Damage()
    {
        return wave5Damage;
    }

    public int GetBulletDamage()
    {
        return bulletsDamage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
