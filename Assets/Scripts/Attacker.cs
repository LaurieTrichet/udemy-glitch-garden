using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private const string VFXParentKey = "VFXParent";
    [Range(0.1f, 3.0f)]
    [SerializeField] float speed = 0.0f;

    [SerializeField] AudioClip deathSFX = null;
    [SerializeField] GameObject deathVFXPrefab = null;
    protected Animator animator = null;
    [SerializeField] int damage = 100;
    [SerializeField] int delayBetweenAttacks = 1;
    protected float currentSpeed = 1;

    protected HealthSystem healthSystem = null;
    protected HealthSystem defenderHealth = null;

    protected Coroutine attackingCoroutine = null;

    private GameObject VFXParent = null;

    public float Speed { get => speed; 
        set {
            speed = value;
            currentSpeed = value;
        }
    }

    public int Damage { get => damage; set => damage = value; }

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
        VFXParent = GameObject.Find(VFXParentKey);
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.hasDiedList.Add(OnHasDied);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    protected void SetMovementSpeed(float value)
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
        var vfx = Instantiate(deathVFXPrefab, transform.position, transform.rotation, VFXParent.transform);
        Destroy(vfx, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var other = collision.gameObject;
        CheckProjectile(other);
        CheckDefender(other);
    }

    protected virtual void CheckDefender(GameObject other)
    {
        var defender = other.GetComponent<Defender>();
        if (defender)
        {
            StartAttacking(defender);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var other = collision.gameObject;
        DidPassDefender(other);
    }

    protected virtual void DidPassDefender(GameObject other)
    {
        //DO NOTHING
    }

    protected void StartAttacking(Defender defender)
    {
        SetAttacking();
        defenderHealth = defender.GetComponent<HealthSystem>();
        defenderHealth.hasDiedList.Add(DefenderHasDied);
        attackingCoroutine = StartCoroutine(AttackCoroutine(defenderHealth));
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
            healthSystem.HandleHit(projectile.Damage);
        }
    }
}
