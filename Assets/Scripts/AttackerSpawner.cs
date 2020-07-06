using System.Collections;
using UnityEngine;
public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] int Min = 3;
    [SerializeField] int Max = 5;
    [SerializeField] bool shouldSpawn = false;

    [SerializeField] GameObject[] prefabs = null;
    [SerializeField] int line = 0;
    private Coroutine spawningCoroutine;

    public int Line { get => line; set => line = value; }

    private void Start()
    {
        spawningCoroutine = StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        while (shouldSpawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(Min, Max));
            Spawn();
        }
    }

    private void Spawn()
    {
        var prefabIndex = UnityEngine.Random.Range(0, prefabs.Length -1);
        var prefab = prefabs[prefabIndex];
        var attacker = Instantiate(prefab, transform.position, transform.rotation, transform);
        attacker.tag = line.ToString() ; 
    }

    public void StopSpawning()
    {
        StopCoroutine(spawningCoroutine);
    }
}
