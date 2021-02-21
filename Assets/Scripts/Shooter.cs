using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Transform handPos;
    [SerializeField] Animator anim;
    [SerializeField] bool canShoot = true;
    [SerializeField] float coolDown = 2f;

    AttackerSpawner spawner;
    [SerializeField] List<Transform> spawnLines = new List<Transform>();
    [SerializeField] Transform myLameSpawnPoint;
    LevelController levelController;

    private void Awake()
    {
        spawner = FindObjectOfType<AttackerSpawner>();
        anim = GetComponent<Animator>();
        levelController = FindObjectOfType<LevelController>();
        SetSpawnLines();
    }

    private void Start()
    {
        SetLaneSpawner();
    }

    private void Update()
    {
        if (IsAttackerInLane() && canShoot)
        {
            StartCoroutine(TriggerShootAnimation());
            Debug.Log("Shoot"); 
        }
        else
        {
            Debug.Log("Wait");
        }
    }

    private IEnumerator TriggerShootAnimation()
    {
        anim.SetTrigger("isAttacking");
        canShoot = false;
        yield return new WaitForSeconds(coolDown);
        canShoot = true;
    }
    private void SetSpawnLines()
    {
        spawnLines = spawner.GetSpawnPoints();
    }
    private bool IsAttackerInLane()
    {
        return myLameSpawnPoint.childCount > 0;
    }
    private void SetLaneSpawner()
    {
        foreach(Transform spawnPoint in spawnLines)
        {
            bool isCloseEnough = Mathf.Abs(spawnPoint.transform.position.y - transform.position.y) <= Mathf.Epsilon;

            if (isCloseEnough)
            {
                myLameSpawnPoint = spawnPoint;
            }
        }
    }

    public void Shoot()
    {
        if (!levelController.IsAlive()) return;
        var projectile = Instantiate(projectilePrefab, handPos.position, Quaternion.identity);
        projectile.transform.parent = transform;
    }
}
