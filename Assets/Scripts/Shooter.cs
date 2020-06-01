using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectilePrefab = null;
    [SerializeField] GameObject projectileLauncher = null;
    [SerializeField] AttackerSpawner attackerSpawner = null;
    [SerializeField] int line = 0;
    private bool shouldShoot = false;


    void Start()
    {
        SetAttackerSpawmer();
    }

    private void SetAttackerSpawmer()
    {
        var defender = GetComponent<Defender>();
        line = defender.Line;
        var attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        attackerSpawner = attackerSpawners.First(spawner => spawner.Line == line);
    }

    public void Shoot(float damage)
    {
        if (shouldShoot)
        {
            var projectile = Instantiate(projectilePrefab, projectileLauncher.transform.position, projectileLauncher.transform.rotation);
            projectile.tag = line.ToString();
        }
    }

    private void Update()
    {
        shouldShoot = IfAttackerInLane();
    }

    private bool IfAttackerInLane()
    {
        return attackerSpawner && attackerSpawner.transform.childCount > 0;
    }
}
