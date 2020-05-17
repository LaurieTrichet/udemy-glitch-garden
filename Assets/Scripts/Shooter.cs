using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField] GameObject projectilePrefab = null;
    [SerializeField] GameObject projectileLauncher = null;
    [SerializeField] int line = 0;



   public void Shoot(float damage)
    {
        var projectile = Instantiate(projectilePrefab, projectileLauncher.transform.position, projectileLauncher.transform.rotation);
        projectile.tag = line.ToString();
    }


}
