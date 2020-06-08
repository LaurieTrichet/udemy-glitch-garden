using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    [SerializeField] GameObject defenderPrefab = null;
    [SerializeField] StarDisplay starDisplay = null;
    private GameObject[,] grid = new GameObject[6, 5];

    void Start()
    {
    }

    public void SetDefenderPrefab(GameObject gameObject)
    {
        defenderPrefab = gameObject;
    }

    public int GetCostForDefender()
    {
        return defenderPrefab.GetComponent<Defender>().Cost;
    }

    public void SpawnDefender(Vector3 position)
    {

        if (defenderPrefab == null) { return; }
        var cost = GetCostForDefender();
        bool isSpaceFree = grid[(int)position.x, (int)position.y] == null;
        if (starDisplay.CanPurchase(cost) && isSpaceFree)
        {
            starDisplay.MakePurchase(cost);
           
            var defenderGameObject = Instantiate(defenderPrefab, position, transform.rotation);
            var defender = defenderGameObject.GetComponent<Defender>();
            defender.Line = Mathf.RoundToInt(position.y)+1;

            grid[(int)position.x, (int)position.y] = defenderGameObject;
        }
    }

    
}
