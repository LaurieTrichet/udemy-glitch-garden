using System;
using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] int Min = 1;
    [SerializeField] int Max = 5;
    [SerializeField] bool shouldSpawn = false;

    [SerializeField] GameObject prefab = null;
    [SerializeField] int line = 0;

    public int Line { get => line; set => line = value; }

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
        var attacker = Instantiate(prefab, transform.position, transform.rotation, transform);
        attacker.tag = line.ToString() ; 
    }

}
