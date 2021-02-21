using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0,5f)]
    float currentSpeed = 0f;
    [SerializeField] GameObject currentTarget;
    [SerializeField] int hits = 1;
    [SerializeField] int stars = 5;
    Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        FindObjectOfType<LevelController>().AttackersSpawned();
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        levelController?.AttackersKilled();

    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.fixedDeltaTime);
    }

    public void SetMovementSpeed(float value)
    {
        currentSpeed = value;
    }

    public void Attack(GameObject target)
    {
        anim.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public int GetStars()
    {
        return stars;
    }
    public void ContinueWalk()
    {
        anim.SetBool("isAttacking", false);
        currentTarget = null;
    }

    public void StrikeCurrentTarget(int damage)
    {
        if (!currentTarget) return;

        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }

    public int GetHits()
    {
        return hits;
    }
}
