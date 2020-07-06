using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{

    private HealthSystem healthSystem = null;
    [SerializeField] LoadingScreen loadingScreen = null;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.hasDiedList.Add(loadingScreen.LoadGameOver);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    var other = collision.gameObject;
    //    TakeDamage(other);
    //}

    //private void TakeDamage(GameObject other)
    //{
    //    var attacker = other.GetComponent<Attacker>();
    //    if (attacker)
    //    {
    //        var damage = attacker.Damage;
    //        healthSystem.HandleHit(damage);
    //    }
    //}
}
