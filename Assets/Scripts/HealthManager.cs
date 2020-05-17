using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] HealthSystem healthSystem = null;

    [SerializeField] TMPro.TMP_Text healthText = null;

    void Start()
    {
        healthSystem.healthHasChanged = OnHealthChange;
        OnHealthChange();
    }


    void OnHealthChange()
    {
        healthText.SetText(healthSystem.Health.ToString());
    }

}
