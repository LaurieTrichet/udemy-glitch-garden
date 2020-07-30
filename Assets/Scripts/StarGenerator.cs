using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    private StarDisplay starDisplay = null;
    [SerializeField] int resource = 2;
    private int maxDifficulty = 6;
    private SettingsController settingsController = null;
    
    // Start is called before the first frame update
    void Start()
    {

        settingsController = FindObjectOfType<SettingsController>();
        starDisplay = FindObjectOfType<StarDisplay>();
        var difficulty = settingsController.GetDifficulty();
        var generatedResources = maxDifficulty - Mathf.RoundToInt(difficulty);
        resource = generatedResources;
    }

    public void Generate()
    {
        starDisplay.Add(resource);
    }
}
