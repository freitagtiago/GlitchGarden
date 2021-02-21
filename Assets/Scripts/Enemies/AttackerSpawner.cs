using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool canSpawn = true;

    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] List<Attacker> enemyPrefab;

    [SerializeField] int minSpawn = 1;
    [SerializeField] int maxSpawn = 6;

    LevelController levelController;

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            int timeToSpawn = Random.Range(minSpawn, maxSpawn + 1);
            yield return new WaitForSeconds(timeToSpawn);
            Spawn();
        }
    }

    private void Spawn()
    {
        Attacker enemyToSpawn = enemyPrefab[Random.Range(0, enemyPrefab.Count)];
        Transform spawnLine = spawnPoints[Random.Range(0, spawnPoints.Count)];
        var attacker = Instantiate(enemyToSpawn, spawnLine);
        attacker.transform.SetParent(spawnLine);
    }

    public List<Transform> GetSpawnPoints()
    {
        return spawnPoints;
    }

    public void StopSpawning()
    {
        canSpawn = false;
    }
    
}
