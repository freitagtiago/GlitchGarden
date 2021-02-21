using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    Text display;
    [SerializeField] int stars = 150;

    private void Start()
    {
        UpdateDisplay(stars);
    }

    private void Awake()
    {
        display = GetComponent<Text>();
    }

    public void UpdateDisplay(int amount)
    {
        display.text = amount.ToString();
    }

    public void AddStars(int starsToAdd)
    {
        stars += starsToAdd;
        UpdateDisplay(stars);
    }

    public void ReduceStars(int starsToReduce)
    {
        if(stars >= starsToReduce)
        {
            stars -= starsToReduce;
            UpdateDisplay(stars);
        }        
    }

    public bool HasEnoughStars(int cost)
    {

        return cost <= stars;
    }
}
