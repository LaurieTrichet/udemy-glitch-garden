using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    [SerializeField] GameObject defenderPrefab = null;
    [SerializeField] StarDisplay starDisplay = null;

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
        var canPurchase = starDisplay.CurrentResources >= cost;
        if (canPurchase)
        {
            MakePurchase(cost);
            Instantiate(defenderPrefab, position, transform.rotation);
        }
    }

    private void MakePurchase(int cost)
    {
        starDisplay.Substract(cost);
    }
}
