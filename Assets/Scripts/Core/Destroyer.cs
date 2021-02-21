using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 2f;
    
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
