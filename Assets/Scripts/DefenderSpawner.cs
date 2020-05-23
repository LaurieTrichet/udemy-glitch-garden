using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    [SerializeField] GameObject defenderPrefab = null;

    public void SpawnDefender(Vector3 position)
    {
        Instantiate(defenderPrefab, position, transform.rotation);
    }


}
