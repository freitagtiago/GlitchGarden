using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Tooltip("Level time in seconds")]
    [SerializeField] float levelTime = 30f;
    [SerializeField] Slider timeSlider;
    [SerializeField] bool timerFinished = false;
    [SerializeField] LevelController levelController;
    private void Awake()
    {
        timeSlider = GetComponent<Slider>();
        levelController = FindObjectOfType<LevelController>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (timerFinished)
        {
            return;
        }

        timeSlider.value = Time.timeSinceLevelLoad / levelTime;
        timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            levelController.LevelTimerFinished();
        }
    }
}
