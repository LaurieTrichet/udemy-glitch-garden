using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    private const int Seconds = 2;
    private StarDisplay starDisplay = null;
    [SerializeField] bool isRunning = true;
    [SerializeField] int resource = 2;

    
    // Start is called before the first frame update
    void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
        StartCoroutine(GenerateCoroutine());
    }


    IEnumerator GenerateCoroutine()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(Seconds);
            Generate();
        }
    }


    private void Generate()
    {
        starDisplay.Add(resource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
