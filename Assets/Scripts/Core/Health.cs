using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 1;
    [SerializeField] GameObject deathFx;
    [SerializeField] bool isEnemy = false;
    Attacker attacker;

    private void Start()
    {
        attacker = GetComponent<Attacker>();
        if (attacker)
        {
            isEnemy = true;
        }
    }

    private void Die()
    {
        if (isEnemy)
        {
            FindObjectOfType<StarDisplay>().AddStars(attacker.GetStars());
        }

        if(deathFx != null)
        {
            Instantiate(deathFx, transform.position, transform.rotation);
        }
        
        Destroy(gameObject);
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void Kill()
    {
        if (deathFx != null)
        {
            Instantiate(deathFx, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
