using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadingTime = 3f;
    [SerializeField] int levelToLoad;
    [SerializeField] bool autoLoad = false;

    private void Start()
    {
        if (autoLoad)
        {
            StartCoroutine(LoadLevel(levelToLoad));
        }
    }

    public IEnumerator LoadLevel(int levelToLoad)
    {
        yield return new WaitForSecondsRealtime(loadingTime);
        Time.timeScale = 1;
        SceneManager.LoadScene(levelToLoad);
    }


    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadSpecificLevel(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
