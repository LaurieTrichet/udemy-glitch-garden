﻿using UnityEngine;
using System.Linq;

public class Shooter : MonoBehaviour
{
    private const string Projectiles = "Projectiles";
    [SerializeField] GameObject projectilePrefab = null;
    [SerializeField] GameObject projectileLauncher = null;
    [SerializeField] AttackerSpawner attackerSpawner = null;
    private Animator animator = null;
    [SerializeField] int line = 0;
    private bool shouldShoot = false;

    private GameObject projectileParent = null;
    void Start()
    {
        animator = GetComponent<Animator>();
        projectileParent = GameObject.Find(Projectiles);
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
            var projectile = Instantiate(projectilePrefab, projectileLauncher.transform.position, projectileLauncher.transform.rotation, projectileParent.transform);
            projectile.tag = line.ToString();
        }
    }

    private void Update()
    {
        shouldShoot = IfAttackerInLane();
        animator.SetBool("shouldShoot", shouldShoot);
    }

    private bool IfAttackerInLane()
    {
        return attackerSpawner && attackerSpawner.transform.childCount > 0;
    }
}
