using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Gravestone>())
        {
            Jump();
        }
        else if(other.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<Attacker>().ContinueWalk();
    }

    private void Jump()
    {
        anim.SetTrigger("isJumping");
    }
}
