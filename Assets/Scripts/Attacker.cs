using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0.1f, 3.0f)]
    float speed = 0.0f;

    [SerializeField] AudioClip deathSFX = null;
    [SerializeField] GameObject deathVFXPrefab = null;
    private Animator animator = null;
    [SerializeField] int damage = 100;
    [SerializeField] int delayBetweenAttacks = 1;
    protected float currentSpeed = 1;

    private HealthSystem healthSystem = null;
    private HealthSystem defenderHealth = null;

    private Coroutine attackingCoroutine = null;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.hasDiedList.Add(OnHasDied);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    void SetMovementSpeed(float value)
    {
        currentSpeed = value;
    }

    void OnHasDied()
    {
        Debug.Log("has died");
        StopAttackingCoroutine();
        if (defenderHealth != null)
        {
            defenderHealth.hasDiedList.Remove(DefenderHasDied);
        }
        AudioSource.PlayClipAtPoint(deathSFX, gameObject.transform.position);
        var vfx = Instantiate(deathVFXPrefab, transform.position, transform.rotation);
        Destroy(vfx, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.gameObject;
        CheckProjectile(other);
        CheckDefender(other);
    }


    protected void CheckDefender(GameObject other)
    {
        var defender = other.GetComponent<Defender>();
        if (defender)
        {
            SetAttacking();
            defenderHealth = defender.GetComponent<HealthSystem>();
            defenderHealth.hasDiedList.Add(DefenderHasDied);
            attackingCoroutine = StartCoroutine(AttackCoroutine(defenderHealth));
        }
    }

    protected void SetAttacking()
    {
        animator.SetBool("shouldAttack", true);
        SetMovementSpeed(0);
    }

    protected void SetNotAttacking()
    {
        if (animator != null)
        {
            animator.SetBool("shouldAttack", false);
        }
        SetMovementSpeed(speed);
    }

    protected void DefenderHasDied()
    {
        StopAttackingCoroutine();
        defenderHealth = null;
        SetNotAttacking();
    }

    private void StopAttackingCoroutine()
    {
        if (attackingCoroutine != null)
        {
            StopCoroutine(attackingCoroutine);
            attackingCoroutine = null;
        }
    }

    protected IEnumerator AttackCoroutine(HealthSystem defenderHealth)
    {
        yield return new WaitForSeconds(delayBetweenAttacks);
        defenderHealth.HandleHit(damage);
    }

    private void CheckProjectile(GameObject other)
    {
        var projectile = other.GetComponent<Projectile>();
        if (projectile)
        {
            Debug.Log("projectile");
            healthSystem.HandleHit(projectile.Damage);
        }
    }
}
