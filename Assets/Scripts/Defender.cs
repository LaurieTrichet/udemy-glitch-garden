using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    private int line = 0;
    [SerializeField] int cost = 0;

    public int Cost { get => cost; set => cost = value; }
    public int Line { get => line; set => line = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

