using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{

    private HealthSystem healthSystem = null;
    [SerializeField] LevelController levelController = null;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        levelController = FindObjectOfType<LevelController>();
        healthSystem.hasDiedList.Add(OnPlayerDidLoose);
    }

    private void OnPlayerDidLoose()
    {
        healthSystem.enabled = false;
        levelController.OnPlayerDidLoose();
    }

}
