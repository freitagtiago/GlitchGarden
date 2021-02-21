using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defenderSelected;
    StarDisplay stars;
    LevelController levelController;
    bool canSpawn = true;
    [SerializeField] Transform defenderContainer;
  

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
        stars = FindObjectOfType<StarDisplay>();   
    }

    private void OnMouseDown()
    {
        if (!defenderSelected) return;
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    private void AttemptToPlaceDefenderAt(Vector2 spawnPos)
    {
        int defenderCost = defenderSelected.GetStarCost();
        if (stars.HasEnoughStars(defenderCost) && canSpawn)
        {
            SpawnDefender(spawnPos);
            stars.ReduceStars(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 spawnPos)
    {
        if (!defenderSelected) return;
        
        Defender newdefender = Instantiate(defenderSelected, spawnPos, Quaternion.identity) as Defender;
        newdefender.transform.parent = defenderContainer;
    }


    public void SelectDefender(Defender defender)
    {
        defenderSelected = defender;
    }

    public void StopSpawning()
    {
        canSpawn = false;
    }
}
