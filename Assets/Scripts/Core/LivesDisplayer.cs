using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LivesDisplayer : MonoBehaviour
{
    Text livesDisplay;
    [SerializeField] GameObject looseDisplay;

    private void Awake()
    {
        livesDisplay = GetComponent<Text>();
    }

    public void UpdateLivesDisplay(float lives)
    {
        livesDisplay.text = lives.ToString() + " LIVES REMAINING!!!";
    }

    public void Loose()
    {
        livesDisplay.text = "0 LIVES REMAINING!!!";
        looseDisplay.SetActive(true);
    }
   
}
