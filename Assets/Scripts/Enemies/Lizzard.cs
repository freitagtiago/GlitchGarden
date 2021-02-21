using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizzard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<Attacker>().ContinueWalk();
    }
}
