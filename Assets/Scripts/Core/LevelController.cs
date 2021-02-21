using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] int numberfAttackers;
    [SerializeField] float baseLives = 50;
    float currentLives;

    [SerializeField] bool isAlive = true;
    [SerializeField] bool timeFinished = false;
    [SerializeField] bool winHasDisplayed = false;
    [SerializeField] bool inLastLevel = false;
    
    [SerializeField] GameObject winDisplay;
    [SerializeField] AudioClip winSound;
    [SerializeField] LivesDisplayer livesDisplayer;
    [SerializeField] GameObject gameCoreArea;

    private void Awake()
    {
        livesDisplayer = FindObjectOfType<LivesDisplayer>();
    }

    void Start()
    {
        currentLives = baseLives - (PlayerPrefsController.GetDifficulty() * 10);
        livesDisplayer.UpdateLivesDisplay(currentLives);
        winDisplay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeFinished && !winHasDisplayed)
        {
            winHasDisplayed = true;
            EndLevel();
        }
    }

    public void EndLevel()
    {
        StartCoroutine(HandleWin());
        StopSpawning();
        KillAllAttackersOnScreen();
    }

    private static void StopSpawning()
    {
        FindObjectOfType<AttackerSpawner>().StopSpawning();
        FindObjectOfType<DefenderSpawner>().StopSpawning();
    }

    private void KillAllAttackersOnScreen()
    {
        foreach(Attacker attacker in FindObjectsOfType<Attacker>())
        {
            attacker.GetComponent<Health>().Kill();
        }
    }

    private IEnumerator HandleWin()
    {
        winDisplay.SetActive(true);
        AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position);
        yield return new WaitForSeconds(3f);
        if (inLastLevel)
        {
            FindObjectOfType<LevelLoader>().LoadSpecificLevel(1);
        }
        else
        {
            FindObjectOfType<LevelLoader>().LoadNextScene();
        }
        
    }

    public void AttackersSpawned()
    {
        numberfAttackers++;
    }

    public void AttackersKilled()
    {
        numberfAttackers--;
    }

    public void LevelTimerFinished()
    {
        timeFinished = true;
    }

    public void UpdateLives(int hitValue)
    {
        currentLives -= hitValue;

        if (currentLives <= 0)
        {
            FindObjectOfType<AttackerSpawner>().StopSpawning();
            FindObjectOfType<AttackerSpawner>().StopSpawning();
            GameOver();
            return;
        }
        livesDisplayer.UpdateLivesDisplay(currentLives);
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        gameCoreArea.SetActive(false);
        isAlive = false;
        livesDisplayer.Loose();
    }
}
