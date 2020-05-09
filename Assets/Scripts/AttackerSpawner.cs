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
        Instantiate(prefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
