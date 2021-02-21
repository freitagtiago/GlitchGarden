using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    DefenderSpawner spawner;
    SpriteRenderer rend;
    Text costLabel;
    [SerializeField] Defender defenderPrefab;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        spawner = FindObjectOfType<DefenderSpawner>();
    }

    private void Start()
    {
        ChangeButtonColor(Color.gray);
        LabelWithCost();
    }

    private void LabelWithCost()
    {
        costLabel = GetComponentInChildren<Text>();
        if (!costLabel)
        {
            Debug.LogError("TEXT COMPONENT NOT FOUND");
            return;
        }
        costLabel.text = defenderPrefab.GetStarCost().ToString();
    }

    private void OnMouseDown()
    {
        ChangeButtonColor(Color.white);
        spawner.SelectDefender(defenderPrefab);
        foreach (DefenderButton button in FindObjectsOfType<DefenderButton>())
        {
            if(button != this)
            {
                button.ChangeButtonColor(Color.gray);
            }
        }
    }

    public void ChangeButtonColor(Color colorToChange)
    {
        rend.color = colorToChange;
    }
}
