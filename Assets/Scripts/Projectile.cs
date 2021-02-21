using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(1,3)]
    [SerializeField] float speed = 1f;
    [SerializeField] int damage = 1;

    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Health health = other.GetComponent<Health>();
            health?.DealDamage(damage);

            Destroy(gameObject, 0.1f);
        }        
    }
}
