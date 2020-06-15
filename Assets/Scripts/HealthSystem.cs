using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int health = 100;

    public int Health
    {
        get
        {
            return health;
        }
    }

    public List<Action> hasDiedList = new List<Action>();
    public List<Action> healthHasChangedList = new List<Action>();

    public void HandleHit(int damage)
    {
        ComputeNewHealth(damage);

        healthHasChangedList.ForEach(healthHasChanged => healthHasChanged.Invoke());
        if (health <= 0)
        {
            hasDiedList.ForEach(healthHasChanged => healthHasChanged.Invoke());
            Destroy(gameObject);
        }
    }

    private void ComputeNewHealth(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
    }
}
