using System;
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

    public Action hasDied = null;
    public Action healthHasChanged = null;

    public void HandleHit(int damage)
    {
        ComputeNewHealth(damage);

        healthHasChanged?.Invoke();
        if (health <= 0)
        {
            hasDied?.Invoke();
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
