using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                DamageOther(collision.gameObject);
                break;
        }
    }

    void DamageOther(GameObject other)
    {
        var health = other.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(damage);
        }
    }
}
