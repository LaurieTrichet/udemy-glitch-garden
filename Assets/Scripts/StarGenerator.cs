using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    private StarDisplay starDisplay = null;
    [SerializeField] int resource = 2;

    
    // Start is called before the first frame update
    void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void Generate()
    {
        starDisplay.Add(resource);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
