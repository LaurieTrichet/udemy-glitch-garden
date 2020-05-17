using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] int Min = 1;
    [SerializeField] int Max = 5;
    [SerializeField] bool shouldSpawn = false;

    [SerializeField] GameObject prefab = null;
    [SerializeField] int line = 0;

    IEnumerator Start()
    {
        while (shouldSpawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(Min, Max));
            Spawn();
        }
    }

    private void Spawn()
    {
        var attacker = Instantiate(prefab, transform.position, transform.rotation);
        attacker.tag = line.ToString() ; 
    }

    // Update is called once per frame
    void Update()
    {

    }
}
