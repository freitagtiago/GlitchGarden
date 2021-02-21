using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimit : MonoBehaviour
{
    [SerializeField] LevelController levelController;
    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            levelController.UpdateLives(other.GetComponent<Attacker>().GetHits());
            Destroy(other.gameObject, 0.01f);
        }
        else if (other.GetComponent<Projectile>())
        {
            Destroy(other.gameObject);
        }

    }
}
