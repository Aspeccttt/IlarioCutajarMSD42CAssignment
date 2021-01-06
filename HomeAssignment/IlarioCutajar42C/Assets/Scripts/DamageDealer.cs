using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damageDealer = 1;

    public int GetDamageDealerContent()
    {
        return damageDealer;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
